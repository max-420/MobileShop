using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class OrderEditVM
    {
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Контактный телефон")]
        public string ContactPhoneNumber { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        public Order ToModel()
        {
            return new Order
            {
                Address = Address,
                ContactPhoneNumber = ContactPhoneNumber,
                Comment = Comment
            };
        }
    }
}