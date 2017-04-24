using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;

namespace MobileShop.Areas.Admin.ViewModels
{
    public class OrderSearchVM
    {
        public OrderSearchVM()
        {

        }
        public OrderSearchVM(OrderSearch os)
        {
            TimeFilters = new SelectList(os.TimeFilters,"Value","Key",os.TimeFilterDays);
            TimeFilterDays = os.TimeFilterDays;
            Statuses = new SelectList(os.Statuses);
            Status = os.Status;
        }
        public SelectList TimeFilters { get; set; }
        [Display(Name = "Время")]
        public int? TimeFilterDays { get; set; }
        public SelectList Statuses { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        public OrderSearch ToModel()
        {
            return new OrderSearch
            {
                TimeFilterDays = TimeFilterDays,
                Status = Status
            };
        }
    }
}