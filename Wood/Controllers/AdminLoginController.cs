using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoodModel;
namespace Wood.Controllers
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public JsonResult Login()
        {
            var UserName = Request.Params["username"];
            var Password = Request.Params["password"];

            string result = string.Empty;
            UserInfoModel user = WoodBuss.BussFactory.Instance.UserBuss.GetUserModel(UserName.ToString(), ref result);

            if (!string.IsNullOrEmpty(result)) 
            {
                var json = new { code=1,messgae=result};
                return Json(json);
            }

            if (user == null) 
            {
                var json = new { code=2,message="查无用户" };
            }

            if (user.Password != Password.ToString()) 
            {
                var json = new { code = 3, message = "密码错误" };
            }

            var returnJson = new { code = 0, message = "登录成功" };

            return Json(returnJson);
        }

	}
}