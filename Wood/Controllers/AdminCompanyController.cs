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
	}
}