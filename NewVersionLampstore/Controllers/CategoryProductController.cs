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
    public class CategoryProductController : OrderController<CategoryProduct, IOrderService<CategoryProduct>>
    {
        public CategoryProductController(IOrderService<CategoryProduct> _service) : base(_service) { }

        

        #region Actions

        // Обрабатываем форму добавления категории к товару
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Add(int? CategoryID, int ProductID)
        {
            Product product = (new ProductEntityService() ).Get(ProductID);

            if (CategoryID.HasValue && product.CategoryProducts.Where(item => item.CategoryID == CategoryID.Value).Count() == 0)
            {
                CategoryProduct obj = new CategoryProduct();
                obj.CategoryID = CategoryID.Value;
                obj.ProductID = ProductID;
                AddValuesOnCreate(obj);
                service.Create(obj);
            }

            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = product.Manufacturer.ShortName, product = product.ShortName });
        }

        #endregion

        #region Overridden virtual methods

        // После перемещения вверх перенаправляем на страницу категории
        protected override ActionResult OnUp(CategoryProduct obj)
        {
            return RedirectToAction("GetByShortName", "Category", new { shortname = obj.Category.ShortName });
        }

        // После перемещения вних перенаправляем на страницу категории
        protected override ActionResult OnDown(CategoryProduct obj)
        {
            return RedirectToAction("GetByShortName", "Category", new { shortname = obj.Category.ShortName });
        }

        // Перенаправляем на страницу товара
        protected override ActionResult ReturnToList(CategoryProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        // Перенаправляем на страницу товара
        protected override ActionResult ReturnToObject(CategoryProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        #endregion
    }
}
