using API.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Note.Model;
using Scotch.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Note.Controllers
{
    public class NoteController : Controller
    {
        ScotchesAPI _scotchesAPI = new API.Helper.ScotchesAPI();

        public async Task<IActionResult> Index()
        {
            List<NoteDTO> dto = new List<NoteDTO>();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/notes");
            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<NoteDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(string ScotchId, string NoteId)  //async
        {
            if (NoteId == null || ScotchId == null)
            {
                return NotFound();
            }

            ScotchDTO scotch = new ScotchDTO();
            NoteDTO dto = new NoteDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/scotches/" + ScotchId);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                scotch = JsonConvert.DeserializeObject<ScotchDTO>(result);
                var notes = scotch.notes;
                foreach (var note in notes)
                {
                    if (note._id == NoteId)
                    {
                        dto = note;
                        dto.dramName = scotch.dramName;
                    }
                }
            }

            if (dto == null)
            {
                return NotFound();
            }
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(dto);
        }

        // GET: Notes/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment")] NoteDTO Note)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Note, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("/api/notes", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Note);
        }

        // GET: Notes/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteDTO dto = new NoteDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/notes/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<NoteDTO>(result);
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);

        }

        // POST: Notes/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, string returnUrl, [Bind("distillerName,flavor,age,style,region,inStock,bottlingNotes,comment,_id")] NoteDTO Note)
        {
            if (id != Note._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _scotchesAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Note), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("/api/notes/" + id, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(Note);
        }

        // GET: Notes/Delete/1  
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteDTO dto = new NoteDTO();
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("/api/notes/" + id);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<NoteDTO>(result);
            }

            //var WishList = dto.SingleOrDefault(m => m.wishListName == wishListName);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: Notes/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            HttpClient client = _scotchesAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync("/api/notes/" + id).Result;
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