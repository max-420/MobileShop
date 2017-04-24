using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MobileShop.ViewModels;
using MobileShop.Models;
using MobileShop.Repository;
using MobileShop.Services;
using Microsoft.AspNet.Identity;
using System.Reflection;

namespace MobileShop.Controllers
{
    public class CatalogController : Controller
    {
        ICatalogService catalogService;
        public CatalogController(ICatalogService catalogServ)
        {
            catalogService = catalogServ;
        }
        public ActionResult Catalog(GoodsSearchVM goodsSearchVM)
        {
            GoodsSearchResult gsr = catalogService.GetCatalog(goodsSearchVM.ToModel());

            string userId = User.Identity.GetUserId();
            Dictionary<Goods, bool> areInBasket = catalogService.AreInBasket(gsr.Items, userId);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CatalogList", gsr.Items.Select(p => new GoodsPreviewVM(p, areInBasket[p])));
            }
            else
            {
                CatalogPageVM catalogPageVM = new CatalogPageVM(gsr, areInBasket);
                return View(catalogPageVM);
            }
        }
        public ActionResult Details(int goodsId, string tab = "features")
        {
            Goods goods = catalogService.GetOne(goodsId);
            string userId = User.Identity.GetUserId();
            bool isInBasket = catalogService.IsInBasket(goods, userId);
            GoodsDetailsVM goodsVM = new GoodsDetailsVM(goods, isInBasket, tab);
            return View(goodsVM);
        }
    }
}