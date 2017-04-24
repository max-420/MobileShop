using System.Collections.Generic;
using MobileShop.Models;

namespace MobileShop.Services
{
    public interface IReviewService:ICRUDService<Review>
    {
        IEnumerable<Review> GetReviews(int goodsId);
    }
}