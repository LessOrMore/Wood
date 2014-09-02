using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodData;
using WoodModel;
namespace WoodBuss
{
    public class UserBuss
    {

        private UserData dal = DataFactory.Instance.UserData;
        public WoodModel.UserInfoModel GetUserModel(string userName,ref string errMsg)
        {
            try 
            {
                UserInfoModel user = dal.GetUserModel(userName);
                return user;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return null;
            }
        }
    }
}
