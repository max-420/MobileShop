using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.Attributes
{
    public class FeatureAttribute:Attribute
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}