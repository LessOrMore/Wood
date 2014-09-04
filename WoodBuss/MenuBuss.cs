using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodModel;
using WoodData;
namespace WoodBuss
{
    public class MenuBuss
    {

        public List<WoodModel.MenuInfoModel> GetMenuList(ref string errMsg)
        {
            try
            {
                List<MenuInfoModel> menuList = DataFactory.Instance.MenuData.GetMenuList();
                return menuList;
            }
            catch (Exception e) 
            {
                errMsg = e.Message;
                return null;
            }
        }
    }
}
