using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitMe.Models
{
    public class User
    {
        public string UName { get; set; }
        public string UPassword { get; set; }
        public string OldPassword { get; set; }
        public decimal UMoney { get; set; }
        public string UAccount { get; set; }
        public string UEmail { get; set; }

    }
}