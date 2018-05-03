using API.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scotch.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Scotch.Controllers
{
    public class ScotchController : Controller
    {
        ScotchesAPI _scotchesAPI = new API.Helper.ScotchesAPI();

        public async Task<IActionResult> Index()
        {
            List<ScotchDTO> dto = new List<ScotchDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/scotches");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<ScotchDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }

        // GET: Scotches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScotchDTO dto = new ScotchDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/scotches/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<ScotchDTO>(result);
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            }

            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // GET: Scotches/Create  
        public IActionResult Create()
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View();
        }

        // POST: Scotches/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment")] ScotchDTO Scotch)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Scotch, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("/api/scotches", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Scotch);
        }

        // GET: Scotches/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScotchDTO dto = new ScotchDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/scotches/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<ScotchDTO>(result);
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);

        }

        // POST: Scotches/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, string returnUrl, [Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment,_id")] ScotchDTO Scotch)
        {
            if (id != Scotch._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Scotch), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("/api/scotches/" + id, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(Scotch);
        }

        // GET: Scotches/Delete/1  
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScotchDTO dto = new ScotchDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/scotches/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<ScotchDTO>(result);
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: Scotches/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync("/api/scotches/" + id).Result;
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