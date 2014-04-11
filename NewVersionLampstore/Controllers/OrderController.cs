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
   
        [Authorize(Roles = Constants.ROLE_ADMIN)]
        public class OrderController : BaseController<Order, IBaseService<Order>>
        {
            public OrderController(IBaseService<Order> _service) : base(_service) { }
          
            protected override bool IsPageable { get { return true; } }

            public ActionResult ChangeStatus(int orderID, int statusID, string currentPage)
            {
                IBaseService<OrderStatus> orderStatusService = new OrderStatusEntityService();
                OrderStatus orderStatus = orderStatusService.Get(statusID);

                if (orderStatus != null)
                {
                    IBaseService<Order> orderService = new OrderEntityService();
                    Order order = orderService.Get(orderID);

                    if (order != null)
                    {
                        order.OrderStatus = orderStatus.Name;
                        orderService.Update(order);
                    }
                }

                return RedirectToAction("Details", new { id = orderID, page = currentPage });
            }
        }

    
}
