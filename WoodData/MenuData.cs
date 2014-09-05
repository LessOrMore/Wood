using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WoodModel;
using WoodComman;
using WoodDBUtility;

namespace WoodData
{

    public class MenuData
    {
        public List<MenuInfoModel> GetMenuList()
        {
            string sql = "select MenuID,ParentMenuID,MenuName,Icon,URL,OrderID from Wood_Admin_MenuInfo order by OrderID asc";
            DataSet ds = SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1)
            {
                return null;
            }
            List<MenuInfoModel> menuList = WoodComman.ConvertHelper<MenuInfoModel>.ConvertToList(ds.Tables[0]);
            return menuList;
        }

        public MenuInfoModel GetMenuModel(string menuID)
        {
            string sql = string.Format("select MenuID,ParentMenuID,MenuName,Icon,URL,OrderID from Wood_Admin_MenuInfo  where MenuID = {0} order by OrderID asc",menuID);
            DataSet ds = SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 0) return null;
            List<MenuInfoModel> menuList = ConvertHelper<MenuInfoModel>.ConvertToList(ds.Tables[0]);
            return menuList[0];
        }

        public List<MenuInfoModel> GetMenuList(string parentMenuID)
        {
            string sql = string.Format("select MenuID,ParentMenuID,MenuName,Icon,URL,OrderID from Wood_Admin_MenuInfo  where ParentMenuID = {0} order by OrderID asc", parentMenuID);
            DataSet ds = SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 0) return null;
            List<MenuInfoModel> menuList = ConvertHelper<MenuInfoModel>.ConvertToList(ds.Tables[0]);
            return menuList;
        }

        public void AddMenu(MenuInfoModel Menu)
        {
            string sql = string.Format(@"insert into Wood_Admin_MenuInfo (ParentMenuID,MenuName,Icon,Url,OrderID) values ({0},'{1}','{2}','{3}','{4}')"
                ,Menu.ParentMenuID,Menu.MenuName,Menu.Icon,Menu.Url,Menu.OrderID);
            SQLiteHelper.ExecuteSql(sql);
        }

        public void EditMenu(MenuInfoModel Menu)
        {
            string sql = string.Format("update Wood_Admin_MenuInfo set ParentMenuID={0},MenuName='{1}',Icon='{2}',Url='{3}' where MenuID={4}"
                , Menu.ParentMenuID, Menu.MenuName, Menu.Icon, Menu.Url, Menu.MenuID);
            SQLiteHelper.ExecuteSql(sql);
        }
    }
}
