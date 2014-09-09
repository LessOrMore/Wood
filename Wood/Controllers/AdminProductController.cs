using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wood.Controllers
{
    public class AdminProductController : Controller
    {
        //
        // GET: /AdminProduct/
        public ActionResult Product()
        {
            return View();
        }

        public ActionResult ProductType() 
        {
            return View();
        }

        public JsonResult ProductTypeDetails() 
        {
            return Json("");
        }
	}
}