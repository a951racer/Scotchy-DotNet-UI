using API.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tasting.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tasting.Controllers
{
    public class TastingController : Controller
    {
        ScotchesAPI _scotchesAPI = new API.Helper.ScotchesAPI();

         public async Task<IActionResult> Index()
        {
            List<TastingDTO> dto = new List<TastingDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/tastings");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<TastingDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }

        // GET: Tastings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<TastingDTO> tastings = new List<TastingDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/tastings");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                tastings = JsonConvert.DeserializeObject<List<TastingDTO>>(result);
            }

            if (tastings == null)
            {
                return NotFound();
            }

            TastingDTO dto = tastings.Find(t => t._id == id);
            
            return View(dto);
        }

        // GET: Tasting/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasting/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment")] TastingDTO Tasting)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Tasting, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("/api/tastings", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Tasting);
        }

        // GET: Tasting/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TastingDTO dto = new TastingDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/tastings/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<TastingDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);

        }

        // POST: Tasting/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment,_id")] TastingDTO Tasting)
        {
            if (id != Tasting._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Tasting), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("/api/tastings/" + id, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Tasting);
        }

        // GET: Scotches/Delete/1  
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TastingDTO dto = new TastingDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/tastings/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<TastingDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: Tasting/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync("/api/tastings/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}