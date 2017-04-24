using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.Areas.Admin.ViewModels
{
    public class PhoneImagesEditVM
    {
        public PhoneImagesEditVM(Goods phone)
        {
            Id = phone.Id;
            ImageThumbnails = phone.Images.Select(p => new ThumbnailWithId {Id = p.Id, Thumbnail = p.Small }).ToList();
            MainImageId = phone.MainImage?.Id;
        }
        public int Id { get; set; }
        public List<ThumbnailWithId> ImageThumbnails { get; set; }
        public int? MainImageId { get; set; }
    }
    public class ThumbnailWithId
    {
        public int Id { get; set; }
        public string Thumbnail { get; set; }
    }
}