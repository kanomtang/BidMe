using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Models
{
    public class User
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}