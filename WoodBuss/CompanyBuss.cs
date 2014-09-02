using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodBuss
{
    public class CompanyBuss
    {

        public WoodModel.CompanyModel GetCompanyModel(ref string errMsg)
        {
            try
            {
                WoodModel.CompanyModel companyModel = WoodData.DataFactory.Instance.CompanyData.GetCompanyModel();
                return companyModel;
            }
            catch (Exception e) 
            {
                errMsg = e.Message;
                return null;
            }
        }
    }
}
