using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MobileShop.ViewModels
{
    public class GoodsSearchVM
    {
        public GoodsSearchVM()
        {

        }

        public GoodsSearchVM(GoodsSearch goodsSearch)
        {
            Page = goodsSearch.Page;
            SortingProperties = new SelectList(goodsSearch.SortingProperties);
            VendorsList = new MultiSelectList(goodsSearch.VendorsList);
            SortBy = goodsSearch.SortBy;
            Category = goodsSearch.Category;
            SortAscending = goodsSearch.SortAscending ?? false;
            PriceRange = goodsSearch.PriceRange;
        }
        public int? Page { get; set; }

        public SelectList SortingProperties;
        [Display(Name = "Сортировка")]
        public string SortBy { get; set; }

        public bool SortAscending { get; set; }
        public string Category { get; set; }

        public MultiSelectList VendorsList { get; set; }
        [Display(Name = "Производитель")]
        public IEnumerable<string> SelectedVendors { get; set; }

        [Display(Name = "Цена")]
        public Range PriceRange { get; set; }

        public GoodsSearch ToModel()
        {
            return new GoodsSearch
            {
                Page = Page,
                SortBy = SortBy,
                SortAscending = SortAscending,
                Category=Category,
                Vendors = SelectedVendors,
                PriceRange = PriceRange
            };
        }
    }
}
