using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionSystem.Models;

namespace AuctionSystem.Models
{
    public class Product
    {

        public string ProductName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int ProductID { get; set; }
        public byte[] image { get; set; }
        public DateTime EndDate { get; set; }
        public IList<Bid> Bids { get; set; }

        public void AddBid(User memberParam,decimal amountParam)
        {
            if (Bids.Count() == 0 || amountParam > Bids.Max(e => e.BidAmount))
            {
                Bids.Add(new Bid() { BidAmount = amountParam, DatePlaced = DateTime.Now, user = memberParam });
            }
            else
            {
                throw new InvalidOperationException("Bid amount too low");
            }
        }

       

        
    }
}