using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Services
{
    public interface ICRUDService<T> where T : class
    {
        T GetOne(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
