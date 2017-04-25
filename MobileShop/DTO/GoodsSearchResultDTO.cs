using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.DTO
{
    public class GoodsSearchResultDTO
    {
        public string CategoryName { get; set; }
        public IEnumerable<Goods> Items { get; set; }
        public GoodsSearchDTO Search { get; set; }
    }
}