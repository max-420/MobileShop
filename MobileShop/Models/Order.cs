using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Адрес должен содержать не менее {0} символов")]
        [MaxLength(50, ErrorMessage = "Адрес должен содержать не более {0} символов")]
        public string Address { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Номер телефона должен содержать не менее {0} символов")]
        [MaxLength(15, ErrorMessage = "Номер телефона должен содержать не более {0} символов")]
        public string ContactPhoneNumber { get; set; }
        [MaxLength(500, ErrorMessage = "Комментарий должен содержать не более {0} символов")]
        public string Comment { get; set; }
        public virtual ICollection<Goods> Goods { get; set; } = new List<Goods>();
    }
}
