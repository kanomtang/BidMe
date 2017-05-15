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

        

       

        
    }
}