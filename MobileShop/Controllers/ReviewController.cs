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
    public class ReviewController : Controller
    {
        IReviewService reviewService;
        public ReviewController(IReviewService reviewSrv)
        {
            reviewService = reviewSrv;
        }
        // GET: Review
        public ActionResult GetReviews(int goodsId)
        {
            IEnumerable<Review> reviews = reviewService.GetReviews(goodsId);
            IEnumerable<ReviewDisplayVM> reviewVMs = reviews.Select(r => new ReviewDisplayVM(r));
            return PartialView("_ReviewsDisplay", reviewVMs);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Add(ReviewEditVM vm)
        {
            Review review = vm.ToModel();
            if (ModelState.IsValid)
            {
                reviewService.Add(review);
            }
            return RedirectToAction("Details", "Catalog", new { goodsId = vm.GoodsId, tab="reviews" });
        }
    }
}