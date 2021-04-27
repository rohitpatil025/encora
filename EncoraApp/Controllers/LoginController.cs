using EncoraApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EncoraApp.Factory;

namespace EncoraApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //Utilized factory pattern 
                LoginFactory factory = new ConcreteLoginFactory();

                ILoginFactory formlogin = factory.GetLogin("form");
                var userDetails = formlogin.Login(model);

                if (userDetails.ID > 0)
                {
                    // if user exists set auth values in cookie
                    FormsAuthentication.SetAuthCookie(userDetails.UserName, false);
                    Session["UserID"] = userDetails.ID;
                    return RedirectToAction("Index", "Notes");
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password");
                }
            }
            return View();

        }

    }
}