using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileShop.Models
{
    public class GoodsImage
    {
        public int Id { get; set; }
        [Required]
        public virtual Goods Goods { get; set; }
        public string Big { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
    }
}