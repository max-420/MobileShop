using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class GoodsImageDisplayVM
    {
        public GoodsImageDisplayVM(GoodsImage image, GoodsImage mainImage)
        {
            Big = image.Big;
            Medium = image.Medium;
            Small = image.Small;
            IsMain = (image.Id == mainImage.Id);
        }
        public string Big { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public bool IsMain { get; set; }
    }
}