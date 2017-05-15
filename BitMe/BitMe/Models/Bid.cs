using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitMe.Models
{
    public class Bid
    {
        public User user { get; set; }
        public Item product { get; set; }
        public Bid(User user, Item product)
        {
            this.user = user;
            this.product = product;
        }

    }
}