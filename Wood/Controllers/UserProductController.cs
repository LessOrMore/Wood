using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wood.Controllers
{
    public class UserProductController : Controller
    {
    
        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductDetails()
        {
            return View();
        }
        /// <summary>
        /// 单个产品
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductInfo()
        {
            return View();
        }
	}
}