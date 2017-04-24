using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Models;

namespace MobileShop.Repository
{
    public interface IRepositoryFactory
    {
        IGoodsRepository<T> CreateGoodsRepository<T>() where T : Goods;
        IRepository<T> CreateRepository<T>() where T : class;
    }
}
