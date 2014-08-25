using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wood.Controllers
{
    public class AdminIndexController : Controller
    {
        //
        // GET: /AdminIndex/
        //
        // GET: /AdminIndex/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Left()
        {
            return View();
        }
        public ActionResult Right()
        {
            return View();
        }
        public ActionResult Top()
        {
            return View();
        }
	}
}