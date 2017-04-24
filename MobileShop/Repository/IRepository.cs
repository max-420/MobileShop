using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MobileShop.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByID(params object[] keys);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}