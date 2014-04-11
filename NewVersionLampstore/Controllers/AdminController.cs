using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewVersionLampstore.Controllers
{
    [Authorize(Roles=NewVersionLampstore.Constants.ROLE_ADMIN)]
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
