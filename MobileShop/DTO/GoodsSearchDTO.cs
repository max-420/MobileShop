using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.DTO
{
    public class GoodsSearchDTO
    {
        public class GoodsSearch
        {
            public int? Page { get; set; }

            public string SortBy { get; set; }
            public string Category { get; set; }

            public IEnumerable<string> SortingProperties { get; set; }
            public bool? SortAscending { get; set; }

            public IEnumerable<string> VendorsList;
            public IEnumerable<string> Vendors { get; set; }

            public Range PriceRange { get; set; }
        }
        public class Range
        {
            public double? Lower { get; set; }
            public double? Upper { get; set; }
        }
    }
}