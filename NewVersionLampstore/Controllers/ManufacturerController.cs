using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Controllers.Abstract;

namespace NewVersionLampstore.Controllers
{
    public class ManufacturerController : UrlFriendlyController<Manufacturer, IUrlFriendlyService<Manufacturer>>
    {
        public ManufacturerController(IUrlFriendlyService<Manufacturer> _service) : base(_service) { }

        #region Overridden virtual methods
        // Включаем постраничный вывод
        protected override bool IsPageable { get { return true; } }


        // На страницу списка переходим через действие GetByShortName без параметров
        protected override ActionResult ReturnToList(Manufacturer obj)
        {
            return RedirectToAction("GetByShortName", new { shortname = string.Empty });
        }

        // На страницу объекта переходим через действие GetByShortName с текстовым параметром shortName
        protected override ActionResult ReturnToObject(Manufacturer obj)
        {
            return RedirectToAction("GetByShortName", new { shortname = obj.ShortName });
        }

        // Свойство ShortName будет автогенерироваться из свойства Name
        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion
    }


}
