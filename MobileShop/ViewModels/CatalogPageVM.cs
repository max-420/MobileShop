using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;
using AutoMapper;
using System.Web.Mvc;

namespace MobileShop.ViewModels
{
    public class CatalogPageVM
    {
        public CatalogPageVM()
        {

        }
        public CatalogPageVM(GoodsSearchResult gsr, Dictionary<Goods, bool> areInBasket)
        {
            
            GoodsPreviews = gsr.Items.Select(p => new GoodsPreviewVM(p, areInBasket[p]));
            Search = new GoodsSearchVM(gsr.Search);
            CategoryName = gsr.CategoryName;
        }
        public IEnumerable<GoodsPreviewVM> GoodsPreviews { get; set; }
        public GoodsSearchVM Search { get; set; }
        public string CategoryName { get; set; }
    }
}