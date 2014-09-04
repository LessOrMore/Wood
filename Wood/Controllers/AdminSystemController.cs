using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoodModel;
using WoodBuss;
namespace Wood.Controllers
{
    public class AdminSystemController : Controller
    {
        //
        // GET: /AdminSystem/
        public ActionResult MenuIndex()
        {
            return View();
        }

        public JsonResult GetMenuData()
        {
            string errMsg = string.Empty;
            List<MenuInfoModel> list = BussFactory.Instance.MenuBuss.GetMenuList(ref errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return Json("result:" + errMsg);
            }
            return Json(list);

        }
	}
}