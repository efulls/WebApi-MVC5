using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApiConsumeXml.Models;

namespace WebApiConsumeXml.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();

            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XML/Customer.xml"));

            //Loop through the selected Nodes.
            foreach (XmlNode node in doc.SelectNodes("/Customer/Index"))
            {
                //Fetch the Node values and assign it to Model.
                customers.Add(new Customer
                {
                    CustomerId = int.Parse(node["Id"].InnerText),
                    Name = node["Name"].InnerText,
                    Country = node["Country"].InnerText
                });
            }

            return View(customers);
        }
    }
}