using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShop.Models
{
    public class Goods
    {
        public virtual string Name
        {
            get
            {
                return Vendor + " " + Model;
            }
        }
        public virtual IEnumerable<string> SummaryFormatString { get; }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual GoodsImage MainImage { get; set; }
        [InverseProperty("Goods")]
        public virtual ICollection<GoodsImage> Images { get; set; } = new List<GoodsImage>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public double AvgRating { get; set; }
        public int OrdersCount{ get; set; }
        public string Description { get; set; }
    }

    
}
