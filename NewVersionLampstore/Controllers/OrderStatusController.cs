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
    
        [Authorize(Roles = Constants.ROLE_ADMIN)]
        public class OrderStatusController : OrderController<OrderStatus, IOrderService<OrderStatus>>
        {
            public OrderStatusController(IOrderService<OrderStatus> _service) : base(_service) { }

            

            protected override ActionResult ReturnToObject(OrderStatus obj)
            {
                return RedirectToAction("Index");
            }
        }

    
}
