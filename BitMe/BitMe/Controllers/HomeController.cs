using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitMe.Entities;
using BitMe.Models;

namespace BitMe.Controllers
{
    public class HomeController : Controller
    {

        User user = new Models.User();
        User model = new User();
        Item item = new Item();

        private ProductRepository repository;


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public new ActionResult Profile()
        {
            //Connect to db and add each data to model to display.
            //such as model.UName = db.Uname;
            User model = new User();
            model.UName = "iJOKE";
            model.UAccount = "chiangmai";
            model.UPassword = "12345*";
            model.UEmail = "Email@gmail";
            model.UMoney = 1000;
            return View(model);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            //Connect to db and add each data to model to display.
            //such as model.UName = db.Uname;
            
            model.UName = "";
            model.UAccount = "";
            model.UPassword = "";
            model.UEmail = "Email@gmail";
   
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(User userProfile)
        {
            if (ModelState.IsValid)
            {
                user.UName = userProfile.UName;
                user.UAccount = userProfile.UAccount;
                user.UPassword = userProfile.UPassword;
                user.UEmail = userProfile.UEmail;
                user.OldPassword = userProfile.OldPassword;
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
        public ActionResult addProduct(Item item)
        {
            if (ModelState.IsValid)
            {
                return View("addsuccess", item);
            }
            else
            {
                //if error
                return View();
            }

        }
        public FileContentResult GetImage()
        {
            byte[] picture = item.picture;
            return File(picture, "image");
        }
    }
}