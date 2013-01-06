using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;


namespace HeylonBlog.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            BLL.Article bll = new Article();
            var list = bll.GetAll(1, 10);
            var model = from a in list
                        select new Models.IndexBlogs()
                        {
                            ArticleID = a.ArticleID,
                            ArticleBrief = a.ArticleContent.Length > 300 ?  a.ArticleContent.Substring(0, 300) + "...":a.ArticleContent,
                            ArticleTitle = a.ArticleTitle,
                            CreateDate = a.CreateDate,
                            IsTop = a.IsTop,
                            ReadNum = a.ReadNum,
                            ReplyNum = a.ArticleReplies.Count,
                            AuthorName = a.User.UserName
                        };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
