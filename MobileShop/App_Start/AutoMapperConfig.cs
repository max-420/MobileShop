using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using MobileShop.Models;
using MobileShop.ViewModels;

namespace MobileShop
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GoodsSearch, GoodsSearchVM>()
                    .ForMember(m => m.VendorsList,
                    op => op.ResolveUsing<MultiSelectListResolver, IEnumerable<string>>(s => s.VendorsList))
                    .ForMember(m => m.SortingProperties,
                    op => op.ResolveUsing<SelectListResolver, IEnumerable<string>>(s => s.SortingProperties));

                cfg.CreateMap<Goods, GoodsPreviewVM>()
                    .ForMember(m => m.MainImageThumbnail,
                    op => op.MapFrom(s => s.MainImage.Small))
                    .ForMember(m => m.BasketState,
                    op => op.UseValue(new BasketButtonVM { PhoneId =1,IsInBasket = false}));


                cfg.CreateMap<GoodsSearchResult, CatalogPageVM>()
                    .ForMember(m => m.GoodsPreviews,
                    op => op.MapFrom(s => s.Items));
            });
        }
        public class MultiSelectListResolver : IMemberValueResolver<object, object, IEnumerable<string>, MultiSelectList>
        {
            public MultiSelectList Resolve(object source, object destination,
                IEnumerable<string> sourceMember, MultiSelectList destinationMember, ResolutionContext context)
            {
                return new MultiSelectList(sourceMember);
            }
        }
        public class SelectListResolver : IMemberValueResolver<object, object, IEnumerable<string>, SelectList>
        {
            public SelectList Resolve(object source, object destination,
                IEnumerable<string> sourceMember, SelectList destinationMember, ResolutionContext context)
            {
                return new SelectList(sourceMember);
            }
        }
    }
}