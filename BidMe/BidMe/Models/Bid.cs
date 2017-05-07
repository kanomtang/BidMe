using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BidMe.Models
{
    public class Bid
    {
        public List<User> user { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal BidAmount { get; set; }

    }
}