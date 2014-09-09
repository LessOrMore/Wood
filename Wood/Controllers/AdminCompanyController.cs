using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoodModel;
namespace Wood.Controllers
{
    public class AdminCompanyController : Controller
    {
        //
        // GET: /AdminCompany/
        public ActionResult Index()
        {
            string errMsg = string.Empty;
            CompanyModel companyModel = WoodBuss.BussFactory.Instance.CompanayBuss.GetCompanyModel(ref errMsg);
            if (!string.IsNullOrEmpty(errMsg)) 
            {
                companyModel= new CompanyModel();
            }
            return View(companyModel);
        }

        public ActionResult Edit()
        {
            string errMsg = string.Empty;
            CompanyModel companyModel = WoodBuss.BussFactory.Instance.CompanayBuss.GetCompanyModel(ref errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                companyModel = new CompanyModel();
            }
            return View(companyModel);
        }
        
        /// <summary>
        /// 跟新公司信息
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateCompany() 
        {
            CompanyModel companyModel = this.GetCompanyModel();
            string errMsg = string.Empty;
            JsonResult res = new JsonResult();
           
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            WoodBuss.BussFactory.Instance.CompanayBuss.UpdateCompanyInfo(companyModel, ref errMsg);
            if (!string.IsNullOrEmpty(errMsg)) 
            {
                var json = new { code="1",message=errMsg};
                res.Data = json;
                return res;
            }
            var returnJson = new { code="0",message="修改成功"};
            res.Data = returnJson;
            return res;
        }

        private CompanyModel GetCompanyModel()
        {
            CompanyModel companyModel = new CompanyModel();

            if (!string.IsNullOrEmpty(Request["CompanyName"])) 
            {
                companyModel.CompanyName = Request["CompanyName"];
            }
            if (!string.IsNullOrEmpty(Request["CompanySummary"]))
            {
                companyModel.CompanySummary = Request["CompanySummary"];
            }
            if (!string.IsNullOrEmpty(Request["CompanyDes"]))
            {
                companyModel.CompanyDes = Request["CompanyDes"];
            }
            if (!string.IsNullOrEmpty(Request["CompanyAddress"]))
            {
                companyModel.CompanyAddress = Request["CompanyAddress"];
            }
            if (!string.IsNullOrEmpty(Request["CompanyTelephone"]))
            {
                companyModel.CompanyTelephone = Request["CompanyTelephone"];
            }
            if (!string.IsNullOrEmpty(Request["CompanyEmail"]))
            {
                companyModel.CompanyEmail = Request["CompanyEmail"];
            }
            return companyModel;
        }
	}
}