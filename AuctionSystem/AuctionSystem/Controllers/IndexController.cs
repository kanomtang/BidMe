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
           //validate user with db here
            return View("Home",user);
        }
        
        public ActionResult Home()
        {
            //show product here!!!
            return View();
        }

        public ActionResult Auction()
        {

            return View();
        }


    }
}