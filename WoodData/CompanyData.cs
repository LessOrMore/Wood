using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WoodDBUtility;
using WoodModel;
using WoodComman;
namespace WoodData
{
    public class CompanyData
    {

        public WoodModel.CompanyModel GetCompanyModel()
        {
            string sql = "select * from Wood_CompanyInfo where ID=1";
            DataSet ds = WoodDBUtility.SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1)
                return null;
            List<CompanyModel> list = ConvertHelper<CompanyModel>.ConvertToList(ds.Tables[0]);
            if (list == null || list.Count < 1) { return null; }
            return list[0];
        }
    }
}
