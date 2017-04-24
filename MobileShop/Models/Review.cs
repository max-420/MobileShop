using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int GoodsId { get; set; }
        public virtual Goods Phone { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public DateTime SendingTime { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Text { get; set; }
    }
}