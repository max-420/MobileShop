using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MobileShop.Models;
using MobileShop.ViewModels;
using MobileShop.Services;

namespace MobileShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderSrv)
        {
            orderService = orderSrv;
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult GetBasketItems()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Goods> goods = orderService.GetBasket(userId);
            IEnumerable<GoodsPreviewVM> goodsVMs = goods.Select(p => new GoodsPreviewVM(p, true));
            return PartialView("_CatalogList", goodsVMs);
        }
        [HttpPost]
        public ActionResult AddToBasket(int goodsId)
        {
            string userId = User.Identity.GetUserId();
            orderService.AddToBasket(goodsId, userId);
            if (Request.IsAjaxRequest())
            {
                return new EmptyResult();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult DeleteFromBasket(int goodsId)
        {
            string userId = User.Identity.GetUserId();
            orderService.DeleteFromBasket(goodsId, userId);
            if (Request.IsAjaxRequest())
            {
                return new EmptyResult();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult GetOrders()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Order> orders = orderService.GetOrders(userId);
            IEnumerable<OrderDisplayVM> orderVMs = orders.Select(o => new OrderDisplayVM(o));
            return PartialView("_OrdersDisplay", orderVMs);
        }
        [HttpPost]
        public ActionResult SendOrder(OrderEditVM orderVM)
        {
            if (ModelState.IsValid)
            {
                Order order = orderVM.ToModel();
                orderService.Add(order);
            }
            else
            {

            }
            return RedirectToAction("Orders");
        }
    }
}