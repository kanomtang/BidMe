using System;
using System.Web.Mvc;
using AuctionSystem.Entities;
using AuctionSystem.Models;

namespace AuctionSystem.Controllers
{
    public class IndexController : Controller
    {

        AuctionDBEntities1 AuctionRepo = new AuctionDBEntities1();
        ProductRepository pd = new ProductRepository();

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
        public ActionResult Iogin(Models.User user)
        {              
                return View("Home", user);
        }
        
        public ActionResult Home()
        {
       
            //show product here!!!
            return View();
        }

        

        [HttpGet]
        public ActionResult SellProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellProduct(Models.Product product)
        {
            return View("AddSuccess",product);
        }
        
        public ActionResult AddSuccess()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Bid(Entities.User user)
        {
            user.Username = "JOKER";
            user.Password = "12345";
            var selectProduct = pd.FetchByID(2);
            Models.Product myProduct = new Models.Product();
            foreach (var x in selectProduct)
            {
                myProduct.ProductName = x.ProductName;
                myProduct.description = x.ProductDescription;
                myProduct.price = x.ProductPrice;
            }
            Bid bid = new Models.Bid(user,myProduct);

            return View(bid);
        }
    }
}