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
    }
}
