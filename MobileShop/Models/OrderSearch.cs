using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class OrderSearch
    {
        public Dictionary<string, int> TimeFilters { get; set; }
        public int? TimeFilterDays { get; set; }
        public IEnumerable<string> Statuses { get; set; }
        public string Status { get; set; }
    }
}