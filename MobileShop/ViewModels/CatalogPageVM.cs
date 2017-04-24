using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class CatalogPageVM
    {
        public CatalogPageVM(GoodsSearchResult gsr, Dictionary<Goods, bool> areInBasket)
        {
            GoodsPreviews = gsr.Items.Select(p => new GoodsPreviewVM(p, areInBasket[p]));
            GoodsSearch = new GoodsSearchVM(gsr.Search);
            CategoryName = gsr.CategoryName;
        }
        public IEnumerable<GoodsPreviewVM> GoodsPreviews { get; set; }
        public GoodsSearchVM GoodsSearch { get; set; }
        public string CategoryName { get; set; }
    }
}