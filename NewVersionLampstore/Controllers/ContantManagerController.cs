using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models;
using System.Web.Security;

namespace NewVersionLampstore.Controllers
{
    [Authorize(Roles = Constants.ROLE_ADMIN)]
    public class ContantManagerController : Controller
    {
        public ActionResult Index()
        {
            List<ContentManager> contentManagers = new List<ContentManager>();

            if (Roles.RoleExists(Constants.ROLE_CONTENT_MANAGER))
            {
                string[] users = Roles.GetUsersInRole(Constants.ROLE_CONTENT_MANAGER);

                foreach (string username in users)
                {
                    UserProfile profile = new UserProfile(username);
                    ContentManager contentManager = new ContentManager() { Login = username, Password = string.Empty, Repeat = string.Empty, FirstName = profile.FirstName, LastName = profile.LastName };
                    contentManagers.Add(contentManager);
                }
            }

            contentManagers = contentManagers.AsQueryable().OrderBy(item => item.LastName).ToList();
            return View(contentManagers);
        }
        public ActionResult Create()
        {
            ContentManager contentManager = new ContentManager();
            return View(contentManager);
        }
        [HttpPost]
        public ActionResult Create(ContentManager contentManager)
        {
            if (ModelState.IsValid)
            {
                if (!Roles.RoleExists(Constants.ROLE_CONTENT_MANAGER))
                    Roles.CreateRole(Constants.ROLE_CONTENT_MANAGER);

                MembershipCreateStatus status = MembershipCreateStatus.UserRejected;

                if (Membership.GetUser(contentManager.Login) == null)
                    Membership.CreateUser(contentManager.Login, contentManager.Password, "mato.84@mail.ru", "Capital of Ukrain", "Kyiv", true, out status);
                else
                {
                    ViewBag.ErrorMessage = "Пользователь с таким логином существует.";
                    return View(contentManager);
                }

                if (status == MembershipCreateStatus.Success)
                {
                    UserProfile profile = new UserProfile(contentManager.Login);
                    profile.FirstName = contentManager.FirstName;
                    profile.LastName = contentManager.LastName;
                    profile.Save();

                    if (!Roles.IsUserInRole(contentManager.Login, Constants.ROLE_CONTENT_MANAGER))
                        Roles.AddUserToRole(contentManager.Login, Constants.ROLE_CONTENT_MANAGER);
                }

                return RedirectToAction("Index");
            }
            else return View(contentManager);
        }
        public ActionResult Delete(string username)
        {
            System.Web.Profile.ProfileManager.DeleteProfile(username);
            Membership.DeleteUser(username);
            return RedirectToAction("Index");
        }


    }
}
