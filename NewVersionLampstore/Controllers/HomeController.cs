using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service;

namespace NewVersionLampstore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View("_Layout");
        }

        
    }
}
