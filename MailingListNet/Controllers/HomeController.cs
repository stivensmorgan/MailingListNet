using MailingListNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailingListNet.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Mailling List";

            HttpClient client = new HttpClient();

            PersonVM[] list = null;
            string path = "https://localhost:44377/api/mailingList";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<PersonVM[]>();
            }

            return View(list);
        }

        [Route("filter")]
        public async Task<ActionResult> Filter(FilterVM filter)
        {
            ViewBag.Title = "Mailling List";

            PersonVM[] list = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44377/api/mailingList");

                HttpResponseMessage response = await client.GetAsync(string.Format("mailingList?lastName={0}&asc={1}", filter.LastName, filter.Asc));

                if (response.IsSuccessStatusCode)
                {
                    list = await response.Content.ReadAsAsync<PersonVM[]>();
                }
                else
                {
                    list = new PersonVM[0];
                }
                //var result = await client.PostAsJsonAsync<FilterVM>("mailingList/filter", filter);

                //if (result.IsSuccessStatusCode)
                //{
                //    list = await result.Content.ReadAsAsync<PersonVM[]>();
                //}
                //else
                //{
                //    list = new PersonVM[0];
                //}

                return View("Index", list);
            }

            //(string.format("api/product?id={0}&type={1}", param.Id.Value, param.Id.Type
            //HttpResponseMessage response = await client.GetAsync(string.Format(path + "?lastName"))
            //if (response.IsSuccessStatusCode)
            //{
            //    list = await response.Content.ReadAsAsync<PersonVM[]>();
            //}
            //else
            //{
            //    list = new PersonVM[0];
            //}

            //return View("Index", list);
        }

        [HttpPost]
        public async Task<ActionResult> Index(PersonVM person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44377/api/mailingList");

                var result = await client.PostAsJsonAsync<PersonVM>("mailingList", person);

                if (result.IsSuccessStatusCode)
                {
                    return View("Confirmation");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }
    }
}
