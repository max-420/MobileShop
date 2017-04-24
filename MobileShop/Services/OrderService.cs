using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;
using MobileShop.Repository;
using Microsoft.AspNet.Identity;

namespace MobileShop.Services
{
    public class OrderService : CRUDService<Order>, IOrderService
    {
        private readonly List<string> statuses = new List<string>
        {
            "Ожидает",
            "В пути",
            "Доставлен"
        };
        private readonly Dictionary<string,int> timeFilters = new Dictionary<string,int>()
        {
            { "1 день", 1},
            { "3 дня", 3},
            { "Неделя", 7},
            {"Месяц", 30 }
        };
        private readonly IGoodsRepository<Goods> goodsRepository;
        private readonly IRepository<User> userRepository;
        public OrderService(IRepositoryFactory rf)
            :base(rf)
        {
            goodsRepository = rf.CreateGoodsRepository<Goods>();
            userRepository = rf.CreateRepository<User>();
        }
        public IEnumerable<Goods> GetBasket(string userId)
        {
            IEnumerable<Goods> basketGoods = userRepository.GetByID(userId).Basket;
            return basketGoods;
        }
        public void AddToBasket(int goodsId, string userId)
        {
            Goods goods = goodsRepository.GetByID(goodsId);
            if (goods != null)
            {
                userRepository.GetByID(userId).Basket.Add(goods);
                userRepository.Save();
            }
        }
        public void DeleteFromBasket(int goodsId, string userId)
        {
            Goods goods = goodsRepository.GetByID(goodsId);
            if (goods != null)
            {
                userRepository.GetByID(userId).Basket.Remove(goods);
                userRepository.Save();
            }
        }
        public OrderSearchResult GetOrders(OrderSearch os)
        {
            OrderSearch updatedSearch = UpdateSearchModel(os);
            IQueryable<Order> query = repository.GetAll();
            if (os.TimeFilterDays != null)
            {
                DateTime minTime = DateTime.Now - TimeSpan.FromDays((double)os.TimeFilterDays);
                query = query.Where(o => o.OrderTime > minTime);
            }
            if (os.Status != null)
            {
                query = query.Where(o=>o.Status==os.Status);
            }
            return new OrderSearchResult { Items = query.ToList(), Search = updatedSearch };
        }
        private OrderSearch UpdateSearchModel(OrderSearch os)
        {
            return new OrderSearch
            {
                TimeFilterDays = os.TimeFilterDays,
                TimeFilters = timeFilters,
                Status = os.Status,
                Statuses = statuses
            };
        }
        public IEnumerable<Order> GetOrders(string userId)
        {
            IEnumerable<Order> orders = userRepository.GetByID(userId).Orders;
            return orders;
        }
        public override void Add(Order order)
        {
            order.OrderTime = DateTime.Now;
            order.Status = statuses[0];
            order.UserId = HttpContext.Current.User.Identity.GetUserId();
            order.Goods = userRepository.GetByID(order.UserId).Basket;
            base.Add(order);
        }
    }
}