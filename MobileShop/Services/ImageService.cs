using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.IO;
using MobileShop.Models;
using ImageResizer;
using MobileShop.Repository;

namespace MobileShop.Services
{
    public class ImageService : IImageService
    {
        public const string ImageDirectory = "Images";
        public const string ImageSubDir = "Goods";
        private readonly IRepository<GoodsImage> imagesRepository;
        private readonly IGoodsRepository<Goods> goodsRepository;
        public ImageService(IRepositoryFactory rf)
        {
            imagesRepository = rf.CreateRepository<GoodsImage>();
            goodsRepository = rf.CreateGoodsRepository<Goods>();
        }
        public void AddImages(int goodsId, List<HttpPostedFileBase> postedImages)
        {
            Goods goods = goodsRepository.GetByID(goodsId);
            if (goods == null) return;
            foreach (HttpPostedFileBase image in postedImages)
            {
                if (image != null)
                {
                    imagesRepository.Add(new GoodsImage
                    {
                        Big = SaveResizedImage(goodsId.ToString(), image, 1000, 1000),
                        Medium = SaveResizedImage(goodsId.ToString(), image, 300, 300),
                        Small = SaveResizedImage(goodsId.ToString(), image, 150, 150)
                    });
                }
            }
            imagesRepository.Save();
        }
        public void DeleteImage(int imgId)
        {
            GoodsImage image = imagesRepository.GetByID(imgId);
            Goods goods = image.Goods;
            if (goods.MainImage != null && goods.MainImage.Id == imgId) goods.MainImage = null;

            DeleteImageFromDisk(image.Big);
            DeleteImageFromDisk(image.Medium);
            DeleteImageFromDisk(image.Small);

            imagesRepository.Delete(image);
            imagesRepository.Save();
        }
        public void SetMainImage(int goodsId, int imgId)
        {
            Goods goods = goodsRepository.GetByID(goodsId);
            goods.MainImage = goods.Images.First(i => i.Id == imgId);
            goodsRepository.Save();
        }
        private string SaveResizedImage(string dir, HttpPostedFileBase image, int maxWidth, int maxHeight)
        {
            string relativePath = "/" + ImageDirectory + "/" + ImageSubDir + "/" + dir + "/";
            string ext = image.FileName.Substring(image.FileName.LastIndexOf(".") + 1);
            string newFileName = Guid.NewGuid().ToString() + '.' + ext;

            string physicalPath = HostingEnvironment.MapPath(relativePath);
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
            }

            string newFilePath = Path.Combine(physicalPath, newFileName);

            string instructions = "maxwidth=" + maxWidth + "&maxheight=" + maxHeight + "&format=" + ext;
            ImageBuilder.Current.Build(
                new ImageJob(
                    image,
                    newFilePath,
                    new Instructions(instructions),
                    false,
                    false));

            return relativePath + newFileName;
        }
        private void DeleteImageFromDisk(string relativePath)
        {
            string filepath = HostingEnvironment.MapPath(relativePath);
            if (File.Exists(filepath))
                File.Delete(filepath);
            //else throw new FileNotFoundException();
        }
    }
}

