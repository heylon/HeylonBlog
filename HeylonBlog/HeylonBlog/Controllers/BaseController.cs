﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeylonBlog.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        [OutputCache(Duration = 1, VaryByParam = "none")]
        public PartialViewResult LeftMenu()
        {
            BLL.Config bll = new BLL.Config();
            var list = bll.GetSections();
            List<Models.SectionShow> sectionList = new List<Models.SectionShow>();
            foreach (var item in list)
            {
                sectionList.Add(new Models.SectionShow(item.SectionTitle, item.SectionContent));
            }
            //ViewBag.LeftMenu = sectionList;

            return PartialView("_LeftMenu", sectionList);
        }

        public BaseController()
        {
            if (Common.HttpContextHelper.GetSession<Model.User>("User") == null)
            {

            }
            else
            {
                ViewBag.IndexBlogEdit = "<a>编辑</a>";
                ViewBag.IndexBlogCreate = "<a class=\"btn btn-small\" href=\"/Blog/Create\">发表新博客</a>";
            }
        }

    }
}
