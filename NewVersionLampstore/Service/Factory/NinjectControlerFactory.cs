using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service.Interface;

namespace NewVersionLampstore.Service.Factory
{
    public class NinjectControlerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernal;
        public NinjectControlerFactory()
        {
            ninjectKernal = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernal.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernal.Bind( typeof( IUrlFriendlyService<Manufacturer>)).To(typeof(ManufacturerEntityService));
            ninjectKernal.Bind<ManufacturerEntityService>().ToSelf();
            ninjectKernal.Bind<ProductEntityService>().ToSelf();
            ninjectKernal.Bind(typeof(IUrlFriendlyService<Product>)).To(typeof(ProductEntityService));
            ninjectKernal.Bind<ProductEntityService>().ToSelf();
            ninjectKernal.Bind(typeof(IUrlFriendlyService<Category>)).To(typeof(CategoryEntityService));
            ninjectKernal.Bind(typeof(IUrlFriendlyService<Collection>)).To(typeof(CollectionEntityService));
            ninjectKernal.Bind(typeof(IOrderService<CollectionImage>)).To(typeof(CollectionImageEntityService));
            ninjectKernal.Bind(typeof(IOrderService<CategoryProduct>)).To(typeof(CategoryProductEntityService));
            ninjectKernal.Bind(typeof(IOrderService<CollectionProduct>)).To(typeof(CollectionProductEntityService));
            ninjectKernal.Bind(typeof(IBaseService<Order>)).To(typeof(OrderEntityService));
            ninjectKernal.Bind(typeof(IBaseService<OrderItem>)).To(typeof(OrderItemEntityService));
            ninjectKernal.Bind(typeof(IOrderService<OrderStatus>)).To(typeof(OrderStatusEntityService));
 
        }
    }
}