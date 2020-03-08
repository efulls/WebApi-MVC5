using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApiConsumeXml.Models;

namespace WebApiConsumeXml.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var categories = GetCategories();
            var homeViewModel = new HomeViewModel
            {
                Categories = new SelectList(categories, "Id", "Value")
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            var test = GetTest(homeViewModel.SelectedCategory);
            var categories = GetCategories();

            homeViewModel.Categories = new SelectList(categories, "Id", "Value");
            homeViewModel.SelectionResult = test;

            return View(homeViewModel);
        }

        private List<Category> GetCategories()
        {
            var xElement = XElement.Load(HttpContext.Server.MapPath("~/XML/Categories.xml"));
            var categoriesFromXml = xElement.Elements();
            var result = categoriesFromXml.Select(category => new Category { Id = category.Value, Value = category.Value }).ToList();

            return result;
        }

        private string GetTest(string id)
        {
            var xElement = XElement.Load(HttpContext.Server.MapPath("~/XML/Tests.xml"));
            var tests = xElement.Elements();
            var element = (from test in tests where test.Element("category").Value == id select test).FirstOrDefault();

            if (element != null)
            {
                var result = element.Element("Name").Value;

                return result;
            }
            return string.Empty;
        }
    }

    

    
}
