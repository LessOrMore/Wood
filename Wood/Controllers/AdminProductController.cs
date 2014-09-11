using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoodBuss;
using WoodModel;
namespace Wood.Controllers
{
    public class AdminProductController : Controller
    {
        #region 产品
        // GET: /AdminProduct/
        public ActionResult Product()
        {
            return View();
        }
        #endregion 

        #region 产品类型
        public ActionResult ProductType() 
        {
            return View();
        }

        public JsonResult ProductTypeDetails() 
        {
            string errMsg = string.Empty;
            Int32 rowCount = 0;
            Dictionary<string, string> param = GetParam();

            List<ProductTypeModel> typeList = WoodBuss.BussFactory.Instance.ProductTypeBuss.GetTypeList(param, ref rowCount, ref errMsg);

            if (typeList == null)
            {
                typeList = new List<ProductTypeModel>();
            }
            var obj = new { total = rowCount, rows = typeList };
            JsonResult res = new JsonResult();
            res.Data = obj;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }
        private Dictionary<string, string> GetParam()
        {
            if (Request.QueryString.Count < 1) { return null; }

            Dictionary<string, string> param = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Request["page"]) && !string.IsNullOrEmpty(Request["rows"]))
            {
                Int32 page = Convert.ToInt32(Request["page"]);
                Int32 rows = Convert.ToInt32(Request["rows"]);
                Int32 StartRows = (page - 1) * rows + 1;
                param.Add("StartRows", StartRows.ToString());
                param.Add("EndRows", (page * rows).ToString());
            }

            return param;
        }
        public ActionResult ProductTypeEdit() 
        {
            SelectList parentList = this.GetParentList();
            ViewBag.ParentList = parentList;

            ProductTypeModel typeModel = new ProductTypeModel();
            return View(typeModel);
        }

        //获取父类List
        private SelectList GetParentList()
        {
            string errMsg = string.Empty;
            List<ProductTypeModel> menuList = BussFactory.Instance.ProductTypeBuss.GetTypeList("-1", ref errMsg);
            if (!string.IsNullOrEmpty(errMsg) && menuList == null)
            {
                menuList = new List<ProductTypeModel>();
            }
            ProductTypeModel first = new ProductTypeModel();
            first.TypeID = -1;
            first.TypeName = "无上级菜单";

            menuList.Insert(0, first);
            SelectList list = new SelectList(menuList, "TypeID", "TypeName", "-1");
            return list;
        }

        [HttpPost]
        public ActionResult ProductTypeEdit(ProductTypeModel typeModel)
        {
            return View(typeModel);
        }


        #endregion
      
	}
}