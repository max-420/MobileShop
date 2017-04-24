using System.Collections.Generic;
using System.Web;

namespace MobileShop.Services
{
    public interface IImageService
    {
        void AddImages(int goodsId, List<HttpPostedFileBase> postedImages);
        void DeleteImage(int imgId);
        void SetMainImage(int goodsId, int imgId);
    }
}