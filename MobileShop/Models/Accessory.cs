using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class Accessory:Goods
    {

        public override string Name
        {
            get
            {
                if (Model == null)
                {
                    return Type + " " + Vendor;
                }
                return base.Name;
            }
        }

        public override IEnumerable<string> SummaryFormatString
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Type { get; set; }
    }
}