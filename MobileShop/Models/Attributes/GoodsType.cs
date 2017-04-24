using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.Attributes
{
    public class GoodsType:Attribute
    {
        public string Name { get; set; }
        public GoodsType(string name)
        {
            Name = name;
        }
    }
}