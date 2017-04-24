using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;
using MobileShop.Areas.Admin.ViewModels;
using MobileShop.Services;

namespace MobileShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderServ)
        {
            orderService = orderServ;
        }
        // GET: Admin/Order
        public ActionResult Index(OrderSearchVM orderSearchVM)
        {
            OrderSearch os = orderSearchVM.ToModel();
            OrderSearchResult osr = orderService.GetOrders(os);
            OrdersManagePageVM pageVM = new OrdersManagePageVM(osr);
            return View("OrdersManage",pageVM);
        }
        [HttpPost]
        public ActionResult EditOrder(IEnumerable<OrderEditVM> orderEditVM)
        {
            IEnumerable <Order> orders = orderEditVM.Select(o=>o.ToModel());
            foreach (Order order in orders)
            {
                orderService.Update(order);
            }
            return RedirectToAction("Index");
        }
    }
}