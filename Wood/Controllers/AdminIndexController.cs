using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoodModel;
using WoodBuss;
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
            UserInfoModel UserInfo = Session["User"] as UserInfoModel;
            ViewBag.UserInfo = UserInfo;

            string errMsg = string.Empty;
            List<MenuInfoModel> menuList = WoodBuss.BussFactory.Instance.MenuBuss.GetMenuList(ref errMsg);
            if (!string.IsNullOrEmpty(errMsg)) 
            {
                menuList = new List<MenuInfoModel>();
            }
            ViewBag.MenuList = menuList;
            return View();
        }

        public ActionResult Main() 
        {
            return View();
        }
	}
}