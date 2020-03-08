using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiConsumeXml.Models
{
    public class HomeViewModel
    {
        public SelectList Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectionResult { get; set; }
    }
}