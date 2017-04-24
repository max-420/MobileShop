using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.ViewModels
{
    public class ReviewEditVM
    {
        public int GoodsId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Не указана оценка")]
        [Display(Name = "Оценка")]
        public int Rating { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Текст отзыва должен содержать не менее {1} символов")]
        [MaxLength(1000, ErrorMessage = "Текст отзыва должен содержать не более {1} символов")]
        [Display(Name = "Текст отзыва")]
        public string Text { get; set; }
        public Review ToModel()
        {
            return new Review
            {
                GoodsId = GoodsId,
                Rating = Rating,
                Text = Text
            };
        }
    }
}