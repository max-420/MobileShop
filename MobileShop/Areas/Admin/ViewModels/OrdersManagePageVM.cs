using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.Areas.Admin.ViewModels
{
    public class OrdersManagePageVM
    {
        public OrdersManagePageVM(OrderSearchResult osr)
        {
            Search = new OrderSearchVM(osr.Search);
            Orders = osr.Items.Select(o => new OrderEditVM(o)).ToList();
        }
        public OrderSearchVM Search { get; set; }
        public List<OrderEditVM> Orders { get; set; } = new List<OrderEditVM>();
    }
}