using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Models;
using System.Web;

namespace MobileShop.Services
{
    public interface ICatalogService:ICRUDService<Goods>
    {
        GoodsSearchResult GetCatalog(GoodsSearch goodsSearch);
        bool IsInBasket(Goods goods, string userId);
        Dictionary<Goods, bool> AreInBasket(IEnumerable<Goods> goods, string userId);
    }
}
