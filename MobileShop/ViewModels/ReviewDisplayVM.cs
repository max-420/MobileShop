using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShop.Models;

namespace MobileShop.ViewModels
{
    public class ReviewDisplayVM
    {
        public ReviewDisplayVM()
        {

        }
        public ReviewDisplayVM(Review review)
        {
            Id = review.Id;
            UserName = review.User.UserName;
            SendingTime = review.SendingTime.ToString();
            Rating = review.Rating;
            Text = review.Text;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string SendingTime { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
    }
}