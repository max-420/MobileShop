using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using MobileShop.Models;

namespace MobileShop.Repository
{
    public class GoodsRepository<T>:Repository<T>, IGoodsRepository<T> where T:Goods
    {
        public GoodsRepository(ApplicationContext appContext) : base(appContext)
        {
        }

        public void UpdateAverageRating(Goods goods)
        {
            if (goods.Reviews.Any())
            {
                goods.AvgRating = goods.Reviews.Average(r => r.Rating);
            }
            else
            {
                goods.AvgRating = 0;
            }
        }
        public void UpdateOrdersCount(Goods goods)
        {
            goods.OrdersCount=goods.Orders.Count();
        }
        public IEnumerable<P> GetPropertyValues<P>(Expression<Func<T, P>> expression)
        {
            IQueryable<P> values = context.Set<T>().Select(expression).Distinct();
            return values.ToList();
        }
    }
}