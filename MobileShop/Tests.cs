using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;

using NUnit.Framework;
using MobileShop.Services;
using MobileShop.Models;
using MobileShop.ViewModels;
using System.Web.UI;
using FakeHttpContext;
using Moq;

namespace MobileShop
{
    [TestFixture]
    public class Tests
    {
        //[Test]
        public void GetCatalog()
        {
            //CatalogService cs = new CatalogService();
            //IEnumerable<Goods> p = cs.GetCatalog<Goods>(cs.SetSearchDefaultFields(new GoodsSearch()),null);
        }
        [Test]
        public void VM()
        {
            var gdvm = new GoodsDetailsVM(new Phone(), true, "features");
        }
    }
}