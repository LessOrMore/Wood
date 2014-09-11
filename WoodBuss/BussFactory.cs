using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodBuss
{
    /// <summary>
    /// 业务层工厂
    /// </summary>
    public class BussFactory
    {
        #region 单例返回本身
        private static BussFactory instanse;
        public static BussFactory Instance 
        {
            get 
            {
                if (instanse == null)
                {
                    instanse = new BussFactory();
                }
                return instanse;
            }

        }
        #endregion 

        #region  后台用户登录

        private UserBuss userBuss;

        public UserBuss UserBuss 
        {
            get 
            {
                if(userBuss==null)
                { userBuss = new UserBuss(); }
                return userBuss;
            }
        }

        #endregion 

        #region 菜单管理
        private MenuBuss menuBuss;
        public MenuBuss MenuBuss 
        {
            get 
            {
                if (menuBuss == null) 
                {
                    menuBuss = new MenuBuss();
                }
                return menuBuss;
            }
        }
        #endregion

        #region 信息设置
        private CompanyBuss companyBuss;
        public CompanyBuss CompanayBuss 
        {
            get 
            {
                if (companyBuss == null) 
                {
                    companyBuss = new CompanyBuss();
                }
                return companyBuss;
            }
        }

        #endregion 

        #region 产品
        private ProductTypeBuss productType;
        public ProductTypeBuss ProductTypeBuss 
        {
            get 
            {
                if (productType == null) 
                {
                    productType = new ProductTypeBuss();
                }
                return productType;
            }
        }
        #endregion 

    }
}
