using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;
using MobileShop.Repository;
using Microsoft.AspNet.Identity;

namespace MobileShop.Services
{
    public class ReviewService : CRUDService<Review>, IReviewService
    {
        private readonly IRepository<Review> reviewsRepository;
        private readonly IGoodsRepository<Goods> goodsRepository;
        public ReviewService(IRepositoryFactory rf)
            :base(rf)
        {
            reviewsRepository = rf.CreateRepository<Review>();
            goodsRepository = rf.CreateGoodsRepository<Goods>();
        }
        public IEnumerable<Review> GetReviews(int goodsId)
        {
            IQueryable<Review> reviews = reviewsRepository.GetAll().Where(r=>r.GoodsId==goodsId);
            return reviews.ToList();
        }
        public override void Add(Review review)
        {
            review.UserId = HttpContext.Current.User.Identity.GetUserId();
            review.SendingTime = DateTime.Now;
            reviewsRepository.Add(review);
            reviewsRepository.Save();
            Goods goods = goodsRepository.GetByID(review.GoodsId);
            goodsRepository.UpdateAverageRating(goods);
            goodsRepository.Save();
        }
    }
}