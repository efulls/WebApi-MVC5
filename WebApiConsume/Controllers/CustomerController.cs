using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiConsume.Models;

namespace WebApiConsume.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8186/api/");
                var responseTask = client.GetAsync("customer");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                    readJob.Wait();
                    customer = readJob.Result;
                }
                else
                {
                    customer = Enumerable.Empty<CustomerViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error occured, Please Contact Administrator");
                }
            }
            return View(customer);
        }
    }
}