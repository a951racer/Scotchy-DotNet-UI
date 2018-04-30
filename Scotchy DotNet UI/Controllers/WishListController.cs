using API.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WishList.Model;
using WishListDetails.Model;

namespace WishList.Controllers
{
    public class WishListController : Controller
    {
        ScotchesAPI _scotchesAPI = new API.Helper.ScotchesAPI();

        public async Task<IActionResult> Index()
        {
            List<WishListDTO> dto = new List<WishListDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/wishlists");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<WishListDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }

        // GET: WishLists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WishListDetailsDTO dto = new WishListDetailsDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/wishlists/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<WishListDetailsDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // GET: WishLists/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishLists/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("wishListName,description")] WishListDTO WishList)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(WishList, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("/api/wishlists", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(WishList);
        }

        // GET: WishLists/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WishListDetailsDTO dto = new WishListDetailsDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/wishlists/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<WishListDetailsDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto.wishlist);

        }

        // POST: WishLists/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("wishListName,description,_id")] WishListDTO WishList)
        {
            if (id != WishList._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(WishList, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("/api/wishlists/" + id, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(WishList);
        }

        // GET: WishLists/Delete/1  
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WishListDetailsDTO dto = new WishListDetailsDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/wishlists/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<WishListDetailsDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto.wishlist);
        }

        // POST: WishLists/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync("/api/wishlists/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}