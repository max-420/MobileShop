using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class GoodsPreviewVM
    {
        public GoodsPreviewVM(Goods goods, bool isInBasket)
        {
            Id = goods.Id;
            Price = goods.Price;
            MainImageThumbnail = goods.MainImage?.Small;
            AvgRating = goods.AvgRating;
            Summary = new GoodsFeaturesMapper().GetSummary(goods);
            Name = goods.Name;
            BasketState = new BasketButtonVM { PhoneId = goods.Id, IsInBasket = isInBasket };
    }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string MainImageThumbnail { get; set; }
        public double AvgRating { get; set; }
        public string Summary { get; set; }
        public BasketButtonVM BasketState { get; set; }
    }
}
