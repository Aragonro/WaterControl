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

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignUp(UserViewModel user)
        {

            return Json("You are registered");
        }

        public ActionResult Monitorings()
        {

            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];
            UserViewModel model = new UserViewModel();
            if (email != null && password != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public JsonResult GetMonitorings()
        {

            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];
            UserViewModel model = new UserViewModel();
            if (email != null && password != null)
            {
                List<MonitoringViewModel> result = new List<MonitoringViewModel>();
                var temp = new MonitoringViewModel() { Id = 1, AutoDelivery = true, CountProduct = 1, DeliveryAddress = "Av. Nauki 14", IsProduct = true, IsWorking = true, ProductName = "5 gal", ObserverEmail = "user@gmail.com" };
                result.Add(temp);
                var temp1 = new MonitoringViewModel() { Id = 2, AutoDelivery = false, CountProduct = 5, DeliveryAddress = "Av. Nauki 35", IsWorking = false, ProductName = "5 gal", ObserverEmail = "friend@gmail.com" };
                result.Add(temp1);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("Server Error");
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