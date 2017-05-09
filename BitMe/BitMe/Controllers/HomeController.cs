using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitMe.Models;

namespace BitMe.Controllers
{
    public class HomeController : Controller
    {

        User user = new Models.User();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            //Connect to db and add each data to model to display.
            //such as model.UName = db.Uname;
            User model = new User();
            model.UName = "iJOKE";
            model.UAccountID = 12345;
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
            User model = new User();
            model.UName = "iJOKE";
            model.UAccountID = 12345;
            model.UPassword = "12345*";
            model.UEmail = "Email@gmail";
            model.UMoney = 1000;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(User userProfile)
        {
            if (ModelState.IsValid)
            {
                user.UName = userProfile.UName;
                user.UAccountID = userProfile.UAccountID;
                user.UPassword = userProfile.UPassword;
                user.UEmail = userProfile.UEmail;
                return RedirectToAction("Profile", "Home");
            }
            return View(userProfile);
        }



    }
}