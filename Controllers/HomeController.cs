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

        public ActionResult Loginpage()
        {
            ViewBag.Message = "Welcome to Login Page...";
            return View();
        }

        public ActionResult Registerpage()
        {
            ViewBag.Message = "Welcome to Reigster Page...";
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection data)
        {
            string username = data["username"];
            string account= data["account"];
            string password = data["password"];

            MysqlController.SqlController sql = new MysqlController.SqlController();
            ViewBag.Message = sql.Userregister(username,account,password);
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection data)
        {
            string account = data["account"];
            string password = data["password"];

            MysqlController.SqlController sql = new MysqlController.SqlController();
            Array tempData = sql.Userlogin(account, password).Split(' ');
            ViewBag.Message = tempData.GetValue(0);
            Session.Add("username", tempData.GetValue(1));
  
            return View();
        }
    }
}