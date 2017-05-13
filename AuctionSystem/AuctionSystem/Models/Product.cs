using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Models
{
    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int productID { get; set; }
        public byte[] image { get; set; }

        public Product(String name,String description,decimal price)
        {
            this.name = name;
            this.price = price;
            this.description = description;
        }

        
    }
}