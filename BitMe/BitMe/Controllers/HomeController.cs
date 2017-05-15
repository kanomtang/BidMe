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
        


        [HttpGet]
        public ActionResult Index()
        {
            var productList = db.GetAllProduct();
            return View(productList);
        }

        public new ActionResult Profile()
        {
            //Connect to db and add each data to model to display.
            //such as model.UName = db.Uname;
            //User model = new User();
            //model.UName = "iJOKE";
            //model.UAccount = "chiangmai";
            //model.UPassword = "12345*";
            //model.UEmail = "Email@gmail";
            //model.UMoney = 1000;
            return View(model);
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
            byte[] picture = item.picture;
            return File(picture, "image");
        }

        [HttpGet]
        public ActionResult Bid(int id,User user)
        {
            var selectProduct = db.FetchByID(id);
            Models.Item myProduct = new Models.Item();
            foreach (var x in selectProduct)
            {
                myProduct.ProductName = x.ProductName;
                myProduct.ProductDescription = x.ProductDescription;
                myProduct.ProductID = x.ProductID;
                myProduct.TempWinner = x.BuyerName;
                //myProduct.bidDeadline = x.BidEndTime;
                //myProduct.ProductPrice = x.ProductPrice;
                //myProduct.ProductPrice = x.ProductPrice;
            }
            Bid myBid = new Bid(user,myProduct);
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
                this.user.UEmail = u.UEmail;
                this.user.UAdress = u.UAdress;
                //return View("Index");
                return RedirectToAction("Index","Home",u);
            }
            else
            {
                return View("RegisterPage");
            }

            
        }


    }
}