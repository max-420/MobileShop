//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.IO;
//using System.Web.Hosting;

//using NUnit.Framework;
//using MobileShop.Services;
//using System.Web.UI;
//using FakeHttpContext;

//namespace MobileShop
//{
//    [TestFixture]
//    public class Tests
//    {
//        FakeHttpContext.FakeHttpContext fhc;
//        [TestFixtureSetUp]
//        public void Setup()
//        {
//            fhc = new FakeHttpContext.FakeHttpContext();
//        }
//        [Test]
//        public void SaveImageExisting()
//        {
//                string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\1.jpg", 100, 100);
//                Assert.IsTrue(File.Exists(HostingEnvironment.MapPath(result)));
//        }
//        [Test]
//        public void SaveImageNotExisting()
//        {
//            string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\2.jpg", 100, 100);
//            Assert.IsNull(result);
//        }
//        [Test]
//        public void SaveImageEmptyPath()
//        {
//            string result = ImageManager.SaveResizedImage(25, "", 100, 100);
//            Assert.IsNull(result);
//        }
//        [Test]
//        public void SaveImageZeroSize()
//        {
//            string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\1.jpg", 0, 0);
//            Assert.IsNull(result);
//        }
//        [Test]
//        public void SaveImageZeroHeight()
//        {
//            string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\1.jpg", 100, 0);
//            Assert.IsNull(result);
//        }
//        [Test]
//        public void SaveImageZeroWidth()
//        {
//            string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\1.jpg", 0, 100);
//            Assert.IsNull(result);
//        }
//        [Test]
//        public void DeleteImageExisting()
//        {
//            string result = ImageManager.SaveResizedImage(25, "C:\\Users\\sony\\Downloads\\1.jpg", 100, 100);
//            ImageManager.DeleteImage(result);
//            Assert.IsFalse(File.Exists(HostingEnvironment.MapPath(result)));
//        }
//        [Test]
//        public void DeleteImageNotExisting()
//        {
//            Assert.Throws<FileNotFoundException>(delegate(){ ImageManager.DeleteImage("/Images/1.jpg"); });
//        }
//        [Test]
//        public void DeleteImageEmptyPath()
//        {
//            Assert.Throws<ArgumentNullException>(delegate () { ImageManager.DeleteImage(""); });
//        }
//        [Test]
//        public void DeleteImageNullPath()
//        {
//            Assert.Throws<ArgumentNullException>(delegate () { ImageManager.DeleteImage(null); });
//        }
//        [TestFixtureTearDown]
//        public void TearDown()
//        {
//            Directory.Delete(HostingEnvironment.MapPath("/Images/Phones/25"),true);
//            fhc.Dispose();
//        }
//    }
//}