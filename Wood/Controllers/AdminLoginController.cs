using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wood.Controllers
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login()
        {
            var UserName = Request.Params["username"];
            var Password = Request.Params["password"];

            

            return Json("OK");
        }

	}
}