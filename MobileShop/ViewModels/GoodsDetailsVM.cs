using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileShop.Models;
using MobileShop.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MobileShop.ViewModels
{
    public class GoodsDetailsVM
    {
        public GoodsDetailsVM(Goods goods, bool isInBasket, string tab)
        {
            Tab = tab;
            Id = goods.Id;
            Price = goods.Price;
            AvgRating = goods.AvgRating;
            Summary = new GoodsFeaturesMapper().GetSummaryList(goods);
            Name = goods.Name;
            BasketState = new BasketButtonVM { PhoneId = goods.Id, IsInBasket = isInBasket };
            GoodsImages = goods.Images.Select(i=> new GoodsImageDisplayVM(i,goods.MainImage));
            FeaturesCategories = new GoodsFeaturesMapper().GetFeatures(goods);
        }
        public string Tab { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double AvgRating { get; set; }
        public IEnumerable<string> Summary { get; set; }
        public BasketButtonVM BasketState { get; set; }
        public IEnumerable<GoodsImageDisplayVM> GoodsImages { get; set; }
        public IEnumerable<FeaturesCategoryVM> FeaturesCategories { get; set; }
    }
    public class FeaturesCategoryVM
    {
        public string Name { get; set; }
        public IEnumerable<FeatureVM> Features { get; set; }
    }
    public class FeatureVM
    {
        public bool? Flag { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
