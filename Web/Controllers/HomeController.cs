using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MysqlController;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Loginpage()
        {
            ViewBag.Message = "Welcome to Login Page...";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection data)
        {
            string account = data["account"];
            string password = data["password"];

            MysqlController.SqlController sql = new MysqlController.SqlController();
            ViewBag.Message = sql.addUser(account,password);
            return View();
        }
    }
}