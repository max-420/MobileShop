using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MobileShop.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext context = new ApplicationContext();
        public Repository(ApplicationContext appContext)
        {
            context = appContext;
        }
        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetByID(params object[] keys)
        {
            return context.Set<T>().Find(keys);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var entry = context.Entry(entity);
            foreach (var property in entry.OriginalValues.PropertyNames)
        {
            var original = entry.OriginalValues.GetValue<object>(property);
            var current = entry.CurrentValues.GetValue<object>(property);
            if (original != null && !original.Equals(current))
                entry.Property(property).IsModified = true;
        }
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}