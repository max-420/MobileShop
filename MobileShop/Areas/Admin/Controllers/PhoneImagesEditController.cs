using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MobileShop.Models;
using MobileShop.Areas.Admin.ViewModels;
using MobileShop.Services;

namespace MobileShop.Areas.Admin.Controllers
{
    public class PhoneImagesEditController : Controller
    {
        IImageService imageService;
        ICatalogService catalogService;
        public PhoneImagesEditController(IImageService imageServ, ICatalogService catalogServ)
        {
            imageService = imageServ;
            catalogService = catalogServ;
        }
        // GET: PhoneImagesEdit
        public async Task<ActionResult> Index(int goodsId)
        {
            Goods goods = catalogService.GetOne(goodsId);
            PhoneImagesEditVM vm = new PhoneImagesEditVM(goods);
            return View("_PhoneImagesEdit",vm);
        }
        [HttpPost]
        public async Task<ActionResult> Add(int goodsId, List<HttpPostedFileBase> postedImages)
        {
            imageService.AddImages(goodsId, postedImages);
            return RedirectToAction("Index", new {goodsId = goodsId});
        }
        [HttpPost]
        public async Task<ActionResult> SetMainImage(int goodsId, int imageId)
        {
            imageService.SetMainImage(goodsId, imageId);
            return RedirectToAction("Index", new { goodsId = goodsId });
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int goodsId, int imageId)
        {
            imageService.DeleteImage(imageId);
            return RedirectToAction("Index", new { goodsId = goodsId });
        }
    }
}