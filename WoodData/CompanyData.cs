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

        public void UpdateCompany(CompanyModel companyModel)
        {
            string sql = string.Format(@"update Wood_CompanyInfo set CompanyName='{0}',CompanySummary='{1}',CompanyDes='{2}',
            CompanyAddress = '{3}',CompanyTelePhone='{4}',  CompanyEmail = '{5}' where ID=1",companyModel.CompanyName,companyModel.CompanySummary,companyModel.CompanyDes
                                                                                            ,companyModel.CompanyAddress,companyModel.CompanyTelephone,companyModel.CompanyEmail);

            WoodDBUtility.SQLiteHelper.ExecuteSql(sql);
        }
    }
}
