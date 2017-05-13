using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSystem.Models;

namespace AuctionSystem.Controllers
{
    public class IndexController : Controller
    {
        public static List<Product> productList = new List<Product>();
        Product p1 = new Product("Nike","shose",120);
        Product p2 = new Product("Adidas", "shose", 150);
        
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Iogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Iogin(User user)
        {
            if (user.username=="buyer")
            {        
                return View("Home", user);
            }
            else if (user.username == "seller")
            { 
                return View("SellProduct");
            }
            else
            {
                return View();
            }
           
        }
        
        public ActionResult Home()
        {
            productList.Add(p1);
            productList.Add(p2);
 
            //show product here!!!
            return View();
        }

        public ActionResult Auction()
        {

            return View();
        }
        [HttpGet]
        public ActionResult SellProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellProduct(Product product)
        {
            return View("AddSuccess",product);
        }
        
        public ActionResult AddSuccess()
        {
            return View();
        }
    }
}