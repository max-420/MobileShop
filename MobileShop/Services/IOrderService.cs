using System.Collections.Generic;
using MobileShop.Models;

namespace MobileShop.Services
{
    public interface IOrderService:ICRUDService<Order>
    {
        void AddToBasket(int goodsId, string userId);
        void DeleteFromBasket(int goodsId, string userId);
        IEnumerable<Goods> GetBasket(string userId);
        IEnumerable<Order> GetOrders(string userId);
        OrderSearchResult GetOrders(OrderSearch os);
    }
}