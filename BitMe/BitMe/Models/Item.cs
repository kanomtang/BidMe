using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BitMe.Models
{
    public class Item
    {
        public byte[] pictureByte { get; set; }
        public HttpPostedFileBase image { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int BrandID { get; set; }
        public DateTime bidDeadline { get; set; }
        public string TempWinner { get; set; }
    }
}