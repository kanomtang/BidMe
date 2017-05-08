using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitMe.Models
{
    public class Item
    {
        public byte[] picture { get; set; }
        public double ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double CategoryID { get; set; }
        public int BrandID { get; set; }
        public DateTime bidDeadline { get; set; }
    }
}