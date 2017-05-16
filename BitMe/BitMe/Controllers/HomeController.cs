using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitMe.Entities;
using BitMe.Models;
using System.IO;

namespace BitMe.Controllers
{
    public class HomeController : Controller
    {

        User user = new Models.User();
        User model = new User();
        Item item = new Item();

        ProductRepository db = new ProductRepository();
        


        
        public ActionResult Index()
        {
            var productList = db.GetAllProduct();
            return View(productList);
        }

        [HttpGet]
        public new ActionResult Profile(string username)
        {
            var user = db.FetchUserByName(username);
            Models.User myUser = new Models.User();
            foreach (var x in user)
            {
                myUser.UName = x.UName;
                myUser.UPassword = x.UPassword;
                myUser.UEmail = x.UEmail;
                myUser.UAdress = x.UAddress;
            }

            
            return View(myUser);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(User userProfile)
        {
            
            if (ModelState.IsValid)
            {
                //user.UName = userProfile.UName;
                //user.UAccount = userProfile.UAccount;
                //user.UPassword = userProfile.UPassword;
                //user.UEmail = userProfile.UEmail;
                //user.OldPassword = userProfile.OldPassword;
                return RedirectToAction("Profile", "Home");
            }
            return View(userProfile);
        }

        [HttpGet]
        public ActionResult addProduct()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult addProduct(Item item,HttpPostedFileBase Image)
        {
            db.addItem(item, Image);
         return View("addsuccess",item);
        }

        public FileContentResult GetImage()
        {
            byte[] picture = item.pictureByte;
            return File(picture, "image");
        }

        [HttpGet]
        public ActionResult Bid(int id,User u)
        { 
            var selectProduct = db.FetchByID(id);
            Models.Item myProduct = new Models.Item();
            foreach (var x in selectProduct)
            {
                myProduct.ProductName = x.ProductName;
                myProduct.ProductDescription = x.ProductDescription;
                myProduct.ProductID = x.ProductID;
                myProduct.TempWinner = x.BuyerName;
                myProduct.ProductPrice = (decimal)x.ProductPrice; 
                //myProduct.bidDeadline = x.BidEndTime;
                //myProduct.ProductPrice = x.ProductPrice;
                //myProduct.ProductPrice = x.ProductPrice;
            }

            Bid myBid = new Bid(user,myProduct);
            
            return View(db.Auction(myBid));
            
        }

        
        [HttpPost]
        public ActionResult Bid(int id)
        {
            var selectProduct = db.FetchByID(id);
            Models.Item myProduct = new Models.Item();
            foreach (var x in selectProduct)
            {
                myProduct.ProductName = x.ProductName;
                myProduct.ProductDescription = x.ProductDescription;
                myProduct.ProductID = x.ProductID;
                myProduct.TempWinner = x.BuyerName;
                myProduct.ProductPrice = (decimal)x.ProductPrice;
                //myProduct.bidDeadline = x.BidEndTime;
                //myProduct.ProductPrice = x.ProductPrice;
                //myProduct.ProductPrice = x.ProductPrice;
               
            }

            Bid myBid = new Bid(user, myProduct);
            //db.Auction(myBid);
            return View(myBid);
        }

   
        [HttpGet]
        public ActionResult RegisterPage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterPage(User u)
        {

            if (ModelState.IsValid)
            {
                if (db.checkingDuplicateUsername(u) == 1)
                {
                    db.RegisterNewUser(u);
                    return RedirectToAction("Index", u);
                }
            }
            return View("RegisterPage");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {


            if (db.login(u) == 1)
            {
                this.user.UName = u.UName;
                this.user.UPassword = u.UPassword;
                return RedirectToAction("Index","Home",u);
            }
            else
            {   
                //Aleart to view "Username already exits"
                return RedirectToAction("RegisterPage");
            }

            
        }


    }
}