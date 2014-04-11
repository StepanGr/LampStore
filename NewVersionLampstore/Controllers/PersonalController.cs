using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        

        public ActionResult Index()
        {
            UserProfile profile = new UserProfile(User.Identity.Name);
            return View(profile);
        }
        public ActionResult Edit()
        {
            UserProfile profile = new UserProfile(User.Identity.Name);
            return View(profile);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            UserProfile profile = new UserProfile(User.Identity.Name);
            UpdateModel(profile, collection);
            profile.Save();
            return RedirectToAction("Index");
        }

    }
}
