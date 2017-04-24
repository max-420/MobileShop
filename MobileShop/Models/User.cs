using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MobileShop.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Goods> Basket { get; set; } = new List<Goods>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
