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
    public class CollectionProductController : OrderController<CollectionProduct, IOrderService<CollectionProduct>>
    {
        public CollectionProductController(IOrderService<CollectionProduct> _service) : base(_service) { }

       

        #region Actions

        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Add(int? CollectionID, int ProductID)
        {
            Product product = (new NewVersionLampstore.Service.ProductEntityService()).Get(ProductID);

            if (CollectionID.HasValue && product.CollectionProducts.Where(item => item.CollectionID == CollectionID.Value).Count() == 0)
            {
                CollectionProduct obj = new CollectionProduct();
                obj.CollectionID = CollectionID.Value;
                obj.ProductID = ProductID;
                AddValuesOnCreate(obj);
                service.Create(obj);
            }

            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = product.Manufacturer.ShortName, product = product.ShortName });
        }

        #endregion

        #region Overridden virtual methods

        protected override ActionResult OnUp(CollectionProduct obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Collection.Category.ShortName, collection = obj.Collection.ShortName });
        }

        protected override ActionResult OnDown(CollectionProduct obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Collection.Category.ShortName, collection = obj.Collection.ShortName });
        }

        protected override ActionResult ReturnToList(CollectionProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        protected override ActionResult ReturnToObject(CollectionProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        #endregion
    }
}
