using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Common;

namespace HeylonBlog.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public int Login()
        {
            string username = HttpContextHelper.InputText(Request.Form["username"], 100);
            string password = HttpContextHelper.InputText(Request.Form["password"], 100);

            BLL.Users bll = new BLL.Users();
            if (bll.Login(username, password))
            {
                return 1;
            }
            return 0;
        }

        public void SignOff()
        {
            Session.Remove("user");
        }

    }
}
