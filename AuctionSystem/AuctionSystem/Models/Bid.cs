using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Models
{
    public class Bid
    {
        public Entities.User user { get; set; }
        public Product product { get; set; }
        public Bid(Entities.User user,Product product)
        {
            this.user = user;
            this.product = product;
        }
    }
    
    
}