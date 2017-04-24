using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class GoodsSearchResult
    {
        public string CategoryName { get; set; }
        public IEnumerable<Goods> Items { get; set; }
        public GoodsSearch Search { get; set; }
    }
}