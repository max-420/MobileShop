using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Repository;
using MobileShop.Models;
namespace MobileShop.Services
{
    public abstract class CRUDService<T>:ICRUDService<T> where T : class
    {
        protected readonly IRepository<T> repository;
        public CRUDService(IRepositoryFactory rf)
        {
            repository = rf.CreateRepository<T>();
        }
        public virtual T GetOne(int id)
        {
            return repository.GetByID(id);
        }
        public virtual void Add(T entity)
        {
            repository.Add(entity);
            repository.Save();
        }
        public virtual void Update(T entity)
        {
            repository.Update(entity);
            repository.Save();
        }
        public virtual void Delete(int id)
        {
            T entity = repository.GetByID(id);
            repository.Delete(entity);
        }
    }
}