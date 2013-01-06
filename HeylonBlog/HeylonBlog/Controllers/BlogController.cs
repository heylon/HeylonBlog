using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Common;

namespace HeylonBlog.Controllers
{
    public class BlogController : BaseController
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            BLL.Article bll = new BLL.Article();
            bll.Read(id);
            var ar = bll.GetSingle(id);
            var artleShow = new Models.BlogShow()
            {
                ArticleContent = ar.ArticleContent,
                ArticleID = ar.ArticleID,
                ArticleTitle = ar.ArticleTitle,
                AuthorName = ar.User.UserName,
                CreateDate = ar.CreateDate,
                IsTop = ar.IsTop,
                ReadNum = ar.ReadNum,
                //Replys = (from r in ar.ArticleReplies
                //         where r.Active == 1
                //         orderby r.ReplyTime descending
                //         select new ICollection<Models.BlogReplys>()
                //         {
                //             Active=r.Active,
                //             ArticleID=r.ArticleID,
                //             ArticleReplyID=r.ArticleReplyID,
                //             ReplyContent=r.ReplyContent,
                //             ReplyTime=r.ReplyTime,
                //             ReplyUserEmail=r.ReplyUserEmail,
                //             ToReplyID=r.ToReplyID,
                //             ReplyUserName=r.ReplyUserName,
                //             UserID=r.UserID,
                //             ToReplyUserName=r.ArticleReply1.ReplyUserName
                //         };)
                Replys=ar.ArticleReplies,
                Category=ar.ArticleCategories,
                Tags=ar.ArticleTags
            };

            return View(artleShow);
        }

        public int SubmitReply()
        {
            Model.ArticleReply reply = new Model.ArticleReply()
            {
                Active = 1,
                ArticleID = Convert.ToInt32(Request.Form["ArticleID"]),
                ReplyContent = HttpContextHelper.InputText(Request.Form["ReplyContent"],4000),
                ReplyTime = DateTime.Now,
                ReplyUserEmail = HttpContextHelper.InputText(Request.Form["ReplyUserEmail"],100),
                ReplyUserName = HttpContextHelper.InputText(Request.Form["ReplyUserName"],50),
                ToReplyID = Convert.ToInt32(Request.Form["ToReplyID"]),
                UserID = 0
            };
            BLL.Article bll = new BLL.Article();
            return bll.SubmitReply(reply);
        }

    }
}
