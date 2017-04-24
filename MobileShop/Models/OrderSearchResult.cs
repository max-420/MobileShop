using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class OrderSearchResult
    {
        public IEnumerable<Order> Items { get; set; }
        public OrderSearch Search { get; set; }
    }
}