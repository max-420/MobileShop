using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Models;
using System.Linq.Expressions;

namespace MobileShop.Repository
{
    public interface IGoodsRepository<T>:IRepository<T> where T:Goods
    {
        void UpdateAverageRating(Goods goods);
        void UpdateOrdersCount(Goods goods);
        IEnumerable<P> GetPropertyValues<P>(Expression<Func<T, P>> expression);
    }
}
