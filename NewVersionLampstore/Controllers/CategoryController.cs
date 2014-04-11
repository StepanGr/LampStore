using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Controllers.Abstract;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service.Interface;

namespace NewVersionLampstore.Controllers
{
    public class CategoryController : UrlFriendlyController<Category, IUrlFriendlyService<Category>>
    {
        public CategoryController(IUrlFriendlyService<Category> _service) : base(_service) { }


        #region Overridden virtual methods

       // protected override ActionResult ReturnToList(Category obj)
       // {
          //  return RedirectToAction("Index", "Home");
       // }

        protected override ActionResult ReturnToObject(Category obj)
        {
            return RedirectToAction("GetByShortName", new { shortname = obj.ShortName });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion

    }
}
