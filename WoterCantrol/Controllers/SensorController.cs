using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoterCantrol.Models;

namespace WoterCantrol.Controllers
{
    public class SensorController : Controller
    {
        public ActionResult Sensors()
        {

            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];
            UserViewModel model = new UserViewModel();
            model.Role = "Anonym";
            if (email != null && password != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");

            }
        }

        public JsonResult GetSensors()
        {

            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];

            if (email != null && password != null)
            {
                List<MonitoringViewModel> result = new List<MonitoringViewModel>();
                var temp = new MonitoringViewModel() { Id = 1, AutoDelivery = true, CountProduct = 1, DeliveryAddress = "Av. Nauki 14", IsProduct = true, IsWorking = true, ProductName = "5 gal", ObserverEmail = "user@gmail.com" };
                result.Add(temp);
                var temp1 = new MonitoringViewModel() { Id = 3, AutoDelivery = false, CountProduct = 2, DeliveryAddress = "Av. Nauki 47", IsWorking = true, ProductName = "5 gal", ObserverEmail = "notFriend@gmail.com" };
                result.Add(temp1);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("Server Error");
        }

        public ActionResult EditSensor(int id)
        {

            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];

            if (email != null && password != null)
            {
                return View(id);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult EditSensor(MonitoringViewModel model)
        {
            return Json("Sensor has been changed");
           
        }

        public ActionResult GetSensorById(int id)
        {
            var email = HttpContext.Request.Cookies["email"];
            var password = HttpContext.Request.Cookies["password"];

            if (email != null && password != null)
            {
                List<MonitoringViewModel> result = new List<MonitoringViewModel>();
                var temp = new MonitoringViewModel() { Id = 1, AutoDelivery = true, CountProduct = 1, DeliveryAddress = "Av. Nauki 14", IsProduct = true, IsWorking = true, ProductName = "5 gal", ObserverEmail = "user@gmail.com" };
                result.Add(temp);
                var temp1 = new MonitoringViewModel() { Id = 3, AutoDelivery = false, CountProduct = 2, DeliveryAddress = "Av. Nauki 47", IsWorking = true, ProductName = "5 gal", ObserverEmail = "notFriend@gmail.com" };
                result.Add(temp1);
                if(id == 3)
                {
                    return Json(temp1, JsonRequestBehavior.AllowGet);
                }
                return Json(temp, JsonRequestBehavior.AllowGet);
            }
            return Json("Server Error");
        }
    }
}