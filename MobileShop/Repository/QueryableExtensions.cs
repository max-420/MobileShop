using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Repository
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int pageNum, int pageSize)
        {
            return query.Skip(pageSize * pageNum).Take(pageSize);
        }
    }
}