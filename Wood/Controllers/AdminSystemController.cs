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

        public ActionResult EditMenu() 
        {
            SelectList list = this.GetSelectedList();
            ViewBag.MenuList = list;

            //获取当前MenuID
            MenuInfoModel menu;
            if (Request.QueryString["MenuID"] == null)
            {
                menu = new  MenuInfoModel();
                menu.Flag = 0; //新增
                return View(menu);
            }
            string errMsg = string.Empty;
            string menuID = Request.QueryString["MenuID"];
            menu = BussFactory.Instance.MenuBuss.GetMenuModel(menuID, ref errMsg);
            menu.Flag = 1; // 修改
            if (!string.IsNullOrEmpty(errMsg))
            {
                menu = new MenuInfoModel();
            }
            return View(menu);
        }
        public SelectList GetSelectedList()
        {
            string errMsg = string.Empty;
            List<MenuInfoModel> menuList = BussFactory.Instance.MenuBuss.GetMenuList("-1", ref errMsg);
            if (!string.IsNullOrEmpty(errMsg) && menuList == null)
            {
                menuList = new List<MenuInfoModel>();
            }
            MenuInfoModel first = new MenuInfoModel();
            first.MenuID = -1;
            first.MenuName = "无上级菜单";

            menuList.Insert(0, first);
            SelectList list = new SelectList(menuList, "MenuID", "MenuName", "-1");
            return list;
        }


        [HttpPost]
        public ActionResult Edit(MenuInfoModel Menu)
        {
            try
            {

                string errMsg = string.Empty;
                if (Menu != null && Menu.Flag == 0)
                {
                    //新增
                    BussFactory.Instance.MenuBuss.AddMenu(Menu, ref errMsg);

                }
                else if (Menu != null && Menu.Flag == 1)
                {
                    BussFactory.Instance.MenuBuss.EditMenu(Menu, ref errMsg);

                }
                if (!string.IsNullOrEmpty(errMsg))
                {
                    SelectList list = this.GetSelectedList();
                    ViewBag.MenuList = list;
                    ViewBag.ErrMsg = errMsg;
                    return View(Menu);
                }

                return RedirectToAction("Edit", new { MenuID = Menu.MenuID });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteMenu() 
        {
            return Content("true"); 
        }

	}
}