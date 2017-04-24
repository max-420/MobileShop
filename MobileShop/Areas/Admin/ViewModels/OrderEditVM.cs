using MobileShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.ViewModels
{
    public class OrderEditVM
    {
        public OrderEditVM()
        {

        }
        public OrderEditVM(Order order)
        {
            Id = order.Id;
            User = order.User.Email;
            OrderTime = order.OrderTime.ToString();
            Status = order.Status;
            Address = order.Address;
            ContactPhoneNumber = order.ContactPhoneNumber;
            Comment = order.Comment;
            OrderedGoods = order.Goods.Select(p => new OrderedGoods { Id = p.Id, Name = p.Name });
        }
        public int Id { get; set; }
        [Display(Name = "Пользователь")]
        public string User { get; set; }
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
        public Order ToModel()
        {
            return new Order
            {
                Id = Id,
                Status = Status
            };
        }
    }
    public class OrderedGoods
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}