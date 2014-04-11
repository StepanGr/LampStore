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
    public class CollectionImageController : OrderController<CollectionImage, IOrderService<CollectionImage>>
    {
        public CollectionImageController(IOrderService<CollectionImage> _service) : base(_service) { }

       

        #region Actions

        public ActionResult Upload(HttpPostedFileBase imagefile, int CollectionID)
        {
            if (imagefile != null)
            {
                string strExtension = System.IO.Path.GetExtension(imagefile.FileName);

                if (strExtension.ToLower() == ".gif" || strExtension.ToLower() == ".jpg" || strExtension.ToLower() == ".jpeg" || strExtension.ToLower() == ".png")
                {
                    CollectionImage obj = new CollectionImage();
                    obj.CollectionID = CollectionID;
                    obj.ImageExt = strExtension;
                    AddValuesOnCreate(obj);
                    service.Create(obj);

                    string strSaveFileName = obj.ID + strExtension;
                    string strSaveFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_IMAGE_FOLDER, strSaveFileName);
                    string strSavePreviewFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_IMAGE_FOLDER, Constants.COLLECTION_IMAGE_PREVIEW_FOLDER, strSaveFileName);

                    if (System.IO.File.Exists(strSaveFullPath)) System.IO.File.Delete(strSaveFullPath);
                    if (System.IO.File.Exists(strSavePreviewFullPath)) System.IO.File.Delete(strSavePreviewFullPath);

                    imagefile.ResizeAndSave(Constants.COLLECTION_IMAGE_HEIGHT, Constants.COLLECTION_IMAGE_WIDTH, strSaveFullPath);
                    imagefile.ResizeAndSave(Constants.COLLECTION_IMAGE_PREVIEW_HEIGHT, Constants.COLLECTION_IMAGE_PREVIEW_WIDTH, strSavePreviewFullPath);
                }
            }

            Collection coll = (new CollectionEntityService()).Get(CollectionID);
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = coll.Category.ShortName, collection = coll.ShortName });
        }

        #endregion

        #region Overridden virtual methods

        protected override ActionResult ReturnToList(CollectionImage obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Collection.Category.ShortName, collection = obj.Collection.ShortName });
        }

        protected override ActionResult ReturnToObject(CollectionImage obj)
        {
            return this.ReturnToList(obj);
        }

        protected override void OnDelete(CollectionImage obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.ImageExt))
            {
                string strFilePath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_IMAGE_FOLDER, obj.ID.ToString() + obj.ImageExt.TrimEnd());

                if (System.IO.File.Exists(strFilePath))
                    System.IO.File.Delete(strFilePath);

                string strPreviewFilePath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.COLLECTION_IMAGE_FOLDER, Constants.COLLECTION_IMAGE_PREVIEW_FOLDER, obj.ID.ToString() + obj.ImageExt.TrimEnd());

                if (System.IO.File.Exists(strPreviewFilePath))
                    System.IO.File.Delete(strPreviewFilePath);
            }

            base.OnDelete(obj);
        }

        #endregion
    }
}
