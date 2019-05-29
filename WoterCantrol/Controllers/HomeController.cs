using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoterCantrol.Models;

namespace WoterCantrol.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];
            UserViewModel model = new UserViewModel();
            model.Role = "Anonym";
            if (email != null && password != null)
            {
                if (email.Value == "admin@gmail.com")
                {
                    model.Role = "Admin";
                    model.FirstName = "Vitalii";
                    model.SecondName = "Batuchenko";
                }
                if ( email.Value == "courier@gmail.com")
                {
                    model.Role = "Courier";
                    model.FirstName = "Ivan";
                    model.SecondName = "Ivanovich";
                }
                if (email.Value == "user@gmail.com")
                {
                    model.Role = "User";
                    model.FirstName = "Aleksei";
                    model.SecondName = "Propianat";
                }

            }
            return View(model);
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignIn(UserViewModel user)
        {
            if (user.Email == "admin@gmail.com")
            {
                user.Role = "Admin";
            }
            if (user.Email == "courier@gmail.com")
            {
                user.Role = "Courier";

            }
            if (user.Email == "user@gmail.com")
            {
                user.Role = "User";

            }
            return Json(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}