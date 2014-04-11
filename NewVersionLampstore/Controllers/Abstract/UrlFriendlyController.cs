using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models.Interfaces;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Controllers.Abstract
{
    public abstract class UrlFriendlyController <T,S>:OrderController<T,S>
        where T:class,IUrlFriendly, new()
        where S:IUrlFriendlyService<T>
    {
        public UrlFriendlyController(S _service) : base(_service) { }

        // Отображение объекта с указанным ShortName
        public ActionResult GetByShortName(string shortName, FilterData Filter)
        {
            
            if (typeof(T) == typeof(Category))
            {
                Filter.Category = shortName;
                Session[NewVersionLampstore.Constants.SESSION_FILTER] = Filter;
            }
            
            if (string.IsNullOrWhiteSpace(shortName))
            {
                IEnumerable<T> objs = null;

                if (IsPageable)
                {
                    int page = 1;
                    if (Request.QueryString["page"] != null) page = int.Parse(Request.QueryString["page"]);
                    if (page < 1) page = 1;

                    objs = service.Get(Request.QueryString, (page - 1) * Constants.PAGER_LINKS_PER_PAGE, Constants.PAGER_LINKS_PER_PAGE);
                }
                 else objs = service.Get(Request.QueryString);
                if (User.IsInRole(NewVersionLampstore.Constants.ROLE_ADMIN))
                    return View("Admin_index", objs);
                return View("Index", objs);
            }
            else
            {
                T obj = service.Get(shortName);
                if (obj == null) return View("NotFound");
                if (User.IsInRole(NewVersionLampstore.Constants.ROLE_ADMIN))                    
                    return View("Admin_details", obj);
                return View("Details", obj);
            }
            
        }

        #region Overridden virtual methods

        // При создании или сохранении объекта:
        // если свойство ShortName пустое, формируем его из значения shortNameSource
        // затем проверяем его свойство ShortName и приводим его к уникальному виду
        protected override void ChangeFormCollectionValues(T obj, FormCollection collection)
        {
            base.ChangeFormCollectionValues(obj, collection);

            if (string.IsNullOrWhiteSpace(collection["ShortName"]))
            {
                string shortNameSource = GetShortNameSource(collection);
                if (!string.IsNullOrWhiteSpace(shortNameSource)) collection["ShortName"] = Transliterate(shortNameSource);
            }

            collection["ShortName"] = service.CreateUniqueShortName(obj.ID, collection["ShortName"]);
        }

        #endregion

        #region Virtual methods

        // В классе-потомке можно переопределить этот метод, чтобы он возвращал источник формирования ShortName
        protected virtual string GetShortNameSource(FormCollection collection)
        {
            return string.Empty;
        }

        #endregion

        #region Methods

        // Перевод источника формирования ShortName в маленькие латинские буквы без пробелов
        protected string Transliterate(string param)
        {
            string strResult = string.Empty;

            foreach (char ch in param)
            {
                if (Constants.TRANSLIT.Keys.Contains(ch)) strResult += Constants.TRANSLIT[ch];
            }

            if (String.IsNullOrWhiteSpace(strResult)) strResult += "_";

            return strResult;
        }

        #endregion
        
        
    }
}
