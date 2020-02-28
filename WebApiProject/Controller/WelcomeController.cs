using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace WebApiProject.Controller
{
    public class WelcomeController : ApiController
    {
        // GET: Welcome
        public string Get()
        {
            string strWelcome = "Hello World this is first my API";
            return strWelcome;
        }
    }
}