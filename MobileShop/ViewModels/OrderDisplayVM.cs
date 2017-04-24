using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class OrderDisplayVM
    {
        public OrderDisplayVM(Order order)
        {
            Id = order.Id;
            OrderTime = order.OrderTime.ToString();
            Status = order.Status;
            Address = order.Address;
            ContactPhoneNumber = order.ContactPhoneNumber;
            Comment = order.Comment;
            OrderedGoods = order.Goods.Select(p => new OrderedGoods { Id = p.Id, Name = p.Vendor +' '+ p.Model });
        }
        public int Id { get; set; }
        [Display(Name = "Время отправки")]
        public string OrderTime { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Контактный телефон")]
        public string ContactPhoneNumber { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        [Display(Name = "Товары")]
        public IEnumerable<OrderedGoods> OrderedGoods { get; set; } = new List<OrderedGoods>();
    }
    public class OrderedGoods
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}