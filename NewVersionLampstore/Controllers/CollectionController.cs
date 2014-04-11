using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Controllers.Abstract;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Service;

namespace NewVersionLampstore.Controllers
{
    public class CollectionController : UrlFriendlyController<Collection, IUrlFriendlyService<Collection>>
    {
        public CollectionController(IUrlFriendlyService<Collection> _service) : base(_service) { }

       

        #region Overridden virtual methods

        protected override ActionResult ReturnToList(Collection obj)
        {
            return RedirectToAction("GetByShortName", "Category", new { shortname = obj.Category.ShortName });
        }

        protected override ActionResult ReturnToObject(Collection obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Category.ShortName, collection = obj.ShortName });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        protected override void OnDelete(Collection obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.ImageExt))
            {
                string strFilePath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_MINI_IMAGES_FOLDER, obj.ID.ToString() + obj.ImageExt);

                if (System.IO.File.Exists(strFilePath))
                    System.IO.File.Delete(strFilePath);
            }

            base.OnDelete(obj);
        }

        #endregion

        public ActionResult UploadCatalogImage(HttpPostedFileBase imagefile, int objID)
        {
            // Получаем объект, для которого загружаем картинку
            Collection obj = service.Get(objID);
            if (obj == null) return View("NotFound");

            try
            {
                if (imagefile != null)
                {
                    // Определяем название конечного графического файла вместе с полным путём.
                    // Название файла должно быть такое же, как ID объекта. Это гарантирует уникальность названия.
                    // Расширение должно быть такое же, как расширение у исходного графического файла.
                    string strExtension = System.IO.Path.GetExtension(imagefile.FileName);
                    string strSaveFileName = objID + strExtension;
                    string strSaveFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_MINI_IMAGES_FOLDER, strSaveFileName);

                    // Если файл с таким названием имеется, удаляем его.
                    if (System.IO.File.Exists(strSaveFullPath)) System.IO.File.Delete(strSaveFullPath);

                    // Сохраняем картинку, изменив её размеры.
                    imagefile.ResizeAndSave(Constants.COLLECTION_MINI_IMAGE_HEIGHT, Constants.COLLECTION_MINI_IMAGE_WIDTH, strSaveFullPath);

                    // Расширение файла записываем в базу данных в поле ImageExt.
                    obj.ImageExt = strExtension;

                    service.Update(obj);
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message;
                if (ex.InnerException != null) strErrorMessage = string.Format("{0} --- {1}", strErrorMessage, ex.InnerException.Message);
                ViewBag.ErrorMessage = strErrorMessage;
                return View("Error");
            }

            return ReturnToObject(obj);
        }

        public ActionResult GetCollectionInCategory(string category, string collection)
        {
            Collection obj = service.Get(collection);
            if (obj == null) return View("NotFound");
            if(User.IsInRole(NewVersionLampstore.Constants.ROLE_ADMIN))
                return View("Admin_details", obj);
            return View("Details", obj);
        }
        public ActionResult CollectionImagePreview(int CollectionID, int start)
        {
            Collection collection = service.Get(CollectionID);
            ViewBag.LeftArrow = start - 1;
            if ((start + Constants.COLLECTION_IMAGE_PREVIEW_COUNT) < collection.CollectionImages.Count) ViewBag.RightArrow = start + 1;
            else ViewBag.RightArrow = -1;
            ViewBag.CollectionID = CollectionID;

            var images = collection.CollectionImages.OrderByDescending(item => item.Sequence).Skip(start).Take(Constants.COLLECTION_IMAGE_PREVIEW_COUNT);
            return PartialView("_CollectionImagePreview", images);
        }

        public ActionResult CollectionImage(int CollectionImageID)
        {
            CollectionImage obj = new CollectionImageEntityService().Get(CollectionImageID);
            return PartialView("_CollectionImage", obj);
        }
    }
}
