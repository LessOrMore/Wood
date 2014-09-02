using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WoodComman;
using WoodModel;
using WoodDBUtility;
namespace WoodData
{
    public class UserData
    {

        public WoodModel.UserInfoModel GetUserModel(string userName)
        {
            string sql = string.Format("select ID,UserID,Password,TelePhone,Address from Wood_Admin_UserInfo where UserID='{0}'", userName);

            DataSet ds = SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 0)
                return null;

            List<UserInfoModel> list = ConvertHelper<UserInfoModel>.ConvertToList(ds.Tables[0]);
            if (list == null || list.Count < 0) { return null; }
            return list[0];
            
        }
    }
}
