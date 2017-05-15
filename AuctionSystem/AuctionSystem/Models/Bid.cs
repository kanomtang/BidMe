using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Models
{
    public class Bid
    {
        public User user { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal BidAmount { get; set; }
    }
}