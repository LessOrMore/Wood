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
        public static BussFactory instanse;
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


    }
}
