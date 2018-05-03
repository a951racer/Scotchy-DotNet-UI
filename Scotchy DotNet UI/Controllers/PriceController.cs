using API.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Price.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Price.Controllers
{
    public class PriceController : Controller
    {
        ScotchesAPI _scotchesAPI = new API.Helper.ScotchesAPI();

        public async Task<IActionResult> Index()
        {
            List<PriceDTO> dto = new List<PriceDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/prices");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<PriceDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }

        // GET: prices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PriceDTO dto = new PriceDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/prices/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<PriceDTO>(result);
            }

            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // GET: prices/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: prices/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment")] PriceDTO Price)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Price, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("/api/prices", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Price);
        }

        // GET: prices/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PriceDTO dto = new PriceDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/prices/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<PriceDTO>(result);
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);

        }

        // POST: prices/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, string returnUrl, [Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment,_id")] PriceDTO Price)
        {
            if (id != Price._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Price), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("/api/prices/" + id, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(Price);
        }

        // GET: prices/Delete/1  
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PriceDTO dto = new PriceDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/prices/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<PriceDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: prices/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync("/api/prices/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
        public IActionResult Cancel(string returnUrl)
        {
            return Redirect(returnUrl);
        }

    }
}