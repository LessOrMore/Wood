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

        /// <summary>
        /// 根据MenuID获取MenuID
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public MenuInfoModel GetMenuModel(string menuID, ref string errMsg)
        {
            try
            {
                return DataFactory.Instance.MenuData.GetMenuModel(menuID);
            }
            catch (Exception e) 
            {
                errMsg = e.Message;
                return null;
            }
        }

        public List<MenuInfoModel> GetMenuList(string parentMenuID, ref string errMsg)
        {
            try 
            {
                return DataFactory.Instance.MenuData.GetMenuList(parentMenuID);
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return null;
            }
        }

        public void AddMenu(MenuInfoModel Menu, ref string errMsg)
        {
            try
            {
                DataFactory.Instance.MenuData.AddMenu(Menu);
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
        }

        public void EditMenu(MenuInfoModel Menu, ref string errMsg)
        {
            try
            {
                DataFactory.Instance.MenuData.EditMenu(Menu);
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
        }
    }
}
