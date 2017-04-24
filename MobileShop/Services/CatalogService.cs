using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;
using MobileShop.Models;
using MobileShop.Repository;
using MobileShop.Models.Attributes;

namespace MobileShop.Services
{
    public class CatalogService : CRUDService<Goods>, ICatalogService
    {
        const int pageSize = 10;
        const string defaultCategory = "Phone";
        private Dictionary<string, Expression<Func<Goods, double>>> sortingExpressions =
            new Dictionary<string, Expression<Func<Goods, double>>>()
            {
                { "Популярность",g=>g.OrdersCount},
                { "Цена",g=>g.Price},
                { "Рейтинг",g=>g.AvgRating}
            };
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<GoodsImage> goodsImagesRepository;
        private readonly IRepositoryFactory repositoryFactory;
        public CatalogService(IRepositoryFactory rf)
            : base(rf)
        {
            usersRepository = rf.CreateRepository<User>();
            goodsImagesRepository = rf.CreateRepository<GoodsImage>();
            repositoryFactory = rf;
        }
        public GoodsSearchResult GetCatalog(GoodsSearch goodsSearch)
        {
            var typeName = "MobileShop.Models." + (goodsSearch.Category ?? defaultCategory);
            Type goodsType = Type.GetType(typeName);
            if (goodsType.IsSubclassOf(typeof(Goods)))
            {
                MethodInfo genericMethod = typeof(CatalogService).GetMethod("GetCatalogOfType")
                    .MakeGenericMethod(goodsType);

                GoodsType attr = goodsType.GetCustomAttribute<GoodsType>();
                string categoryName = attr?.Name;

                GoodsSearchResult gsr = (GoodsSearchResult)genericMethod.Invoke(this, new object[] { goodsSearch });
                gsr.CategoryName = categoryName;
                return gsr;
            }
            else return null;
        }
        public GoodsSearchResult GetCatalogOfType<T>(GoodsSearch goodsSearch) where T : Goods
        {
            GoodsSearch goodsSearchUpdated = UpdateSearchModel<T>(goodsSearch);
            IGoodsRepository<T> goodsRepository = repositoryFactory.CreateGoodsRepository<T>();
            IQueryable<T> query = goodsRepository.GetAll();

            if (goodsSearchUpdated.Vendors != null && goodsSearchUpdated.Vendors.Count() != 0)
            {
                query = query.Where(g => goodsSearchUpdated.Vendors.Contains(g.Vendor));
            }
            if (goodsSearchUpdated.PriceRange?.Lower != null) query = query.Where(g => g.Price >= goodsSearchUpdated.PriceRange.Lower);
            if (goodsSearchUpdated.PriceRange?.Upper != null) query = query.Where(g => g.Price <= goodsSearchUpdated.PriceRange.Upper);

            Expression<Func<Goods, double>> sortingExpression = sortingExpressions[goodsSearchUpdated.SortBy];
            if ((bool)goodsSearchUpdated.SortAscending)
            {
                query = query.OrderBy(sortingExpression).Cast<T>();
            }
            else
            {
                query = query.OrderByDescending(sortingExpression).Cast<T>();
            }

            query = query.GetPage((int)goodsSearchUpdated.Page, pageSize);

            IEnumerable<T> catalog = query.ToList();

            return new GoodsSearchResult { Items = catalog, Search = goodsSearchUpdated };
        }

        private GoodsSearch UpdateSearchModel<T>(GoodsSearch gs) where T : Goods
        {
            IGoodsRepository<T> goodsRepository = repositoryFactory.CreateGoodsRepository<T>();
            return new GoodsSearch
            {
                Page = gs.Page ?? 0,
                SortBy = gs.SortBy ?? sortingExpressions.Keys.First(),
                SortAscending = gs.SortAscending ?? false,
                SortingProperties = sortingExpressions.Keys,
                Category = gs.Category ?? defaultCategory,
                Vendors = gs.Vendors ?? new List<string>(),
                VendorsList = goodsRepository.GetPropertyValues(g => g.Vendor),
                PriceRange = gs.PriceRange ?? new Range()
            };
        }
        public bool IsInBasket(Goods goods, string userId)
        {
            if (userId != null)
            {
                return usersRepository.GetByID(userId).Basket.Contains(goods);
            }
            return false;
        }
        public Dictionary<Goods, bool> AreInBasket(IEnumerable<Goods> goods, string userId)
        {
            IEnumerable<Goods> basket;
            if (userId != null) basket = usersRepository.GetByID(userId).Basket;
            else basket = new List<Goods>();
            Dictionary<Goods, bool> result = new Dictionary<Goods, bool>();
            foreach (Goods item in goods)
            {
                bool isInBasket = basket.Contains(item);
                result.Add(item, isInBasket);
            }
            return result;
        }
    }
}