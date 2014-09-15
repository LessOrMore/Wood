using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodData
{
    public class DataFactory
    {
        #region 单利模式

        private static DataFactory instanse;

        public static DataFactory Instance 
        {
            get 
            {
                if (instanse == null) 
                {
                    instanse = new DataFactory();
                }
                return instanse;
            }
        }
        #endregion 

        #region 用户管理
        private UserData userData;
        public UserData UserData 
        {
            get 
            {
                if (userData == null)
                {
                    userData = new UserData();
                }
                return userData;
            }
        }
        #endregion 

        #region 菜单管理

        private MenuData menuData;
        public MenuData MenuData
        {
            get 
            {
                if (menuData == null) 
                {
                    menuData = new MenuData();
                }
                return menuData;
            }
        }
        #endregion 

        #region  公司信息管理
        private CompanyData companyData;

        public CompanyData CompanyData 
        {
            get 
            {
                if (companyData == null) 
                {
                    companyData = new CompanyData();
                }
                return companyData;
            }
        }
        #endregion 

        #region 产品管理
        private ProductTypeData producttypeData;
        public ProductTypeData ProductTypeData 
        {
            get 
            {
                if (producttypeData == null)
                {
                    producttypeData = new ProductTypeData();
                }
                return producttypeData;
            }
        }
        #endregion 
    }
}
