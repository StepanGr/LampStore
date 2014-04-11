using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service;
using NewVersionLampstore.Service.Interface;

namespace NewVersionLampstore.Controllers
{
    public class CartController : Controller
    {
        // Открытие страницы корзины
        public ActionResult Index()
        {
            return View(Session[Constants.SESSION_CART] as Dictionary<int, int>);
        }

        // Добавление товара в корзину
        public ActionResult Add(int id)
        {
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
            if (cart == null) cart = new Dictionary<int, int>();

            if (cart.ContainsKey(id)) cart[id] = cart[id] + 1;
            else cart[id] = 1;

            Session[Constants.SESSION_CART] = cart;

            return RedirectToAction("Index");
        }

        // Изменение количества товара
        public ActionResult ChangeValue(int id, string number)
        {
            int iNumber = 0;

            if (int.TryParse(number, out iNumber) && iNumber > 0)
            {
                Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
                if (cart != null && cart.ContainsKey(id)) cart[id] = iNumber;
                Session[Constants.SESSION_CART] = cart;
            }

            return RedirectToAction("Index");
        }

        // Удаление товара из корзины
        public ActionResult Delete(int id)
        {
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
            if (cart != null && cart.ContainsKey(id)) cart.Remove(id);
            Session[Constants.SESSION_CART] = cart;

            return RedirectToAction("Index");
        }

        // Сохранение заказа
        [HttpPost]
        public ActionResult Save(FormCollection colection)
        {

            ShipInfo shipinfo = new ShipInfo();
            UpdateModel(shipinfo, colection);
            
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;

            if (cart != null)
            {
                Order order = new Order();
                order.Date = DateTime.Now;
                order.FirstName = shipinfo.Name;

                order.LastName = shipinfo.LastName;
                order.Phone = shipinfo.Phone;
                order.Address = shipinfo.Citi;
                order.TypePayment = shipinfo.typePayment;
                order.TypeShipped = shipinfo.typeShipped;
                order.Email = shipinfo.Email;

                order.OrderStatus = string.Empty;
                //int iOrderStatusesNumber = new OrderStatusEntityService().Get().Count();
                //if (iOrderStatusesNumber > 0) order.OrderStatus =  new OrderStatusEntityService().Get().OrderByDescending(item => item.Sequence).First().Name;

                IBaseService<Order> orderService = new OrderEntityService();
                orderService.Create(order);

                List<OrderItem> orderItems = new List<OrderItem>();
                IUrlFriendlyService<Product> productService = new ProductEntityService();

                foreach (int key in cart.Keys)
                {
                    Product product = productService.Get(key);

                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderID = order.ID;
                    orderItem.ProductID = key;
                    orderItem.Name = product.Name;
                    orderItem.Manufacturer = product.Manufacturer.Name;
                    orderItem.Number = cart[key];
                    orderItem.Price = product.Price;
                    orderItems.Add(orderItem);
                }

                IBaseService<OrderItem> orderItemService = new OrderItemEntityService();

                foreach (OrderItem orderItem in orderItems)
                {
                    orderItemService.Create(orderItem);
                }

                Session.Remove(Constants.SESSION_CART);
            }

            return View("ThankYou");
        }
        public ActionResult ShipInform()
        {
            ShipInfo shipinfo = new ShipInfo();
            return View(shipinfo);

        }

        public ActionResult Summary()
        {
            return View();
        }
        
    }
}
