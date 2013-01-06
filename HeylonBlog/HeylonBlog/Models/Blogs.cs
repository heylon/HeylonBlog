﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeylonBlog.Models
{
    public class IndexBlogs
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleBrief { get; set; }
        public DateTime CreateDate { get; set; }
        public int IsTop { get; set; }
        public int ReadNum { get; set; }
        public int ReplyNum { get; set; }
        public string AuthorName { get; set; }
    }

    public class BlogShow
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime CreateDate { get; set; }
        public int IsTop { get; set; }
        public int ReadNum { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Model.ArticleReply> Replys { get; set; }
        public ICollection<Model.ArticleTag> Tags { get; set; }
        public ICollection<Model.ArticleCategory> Category { get; set; }
    }

    public class BlogReplys
    {
        public int ArticleReplyID { get; set; }
        public string ReplyContent { get; set; }
        public string ReplyUserName { get; set; }
        public string ReplyUserEmail { get; set; }
        public DateTime ReplyTime { get; set; }
        public int ArticleID { get; set; }
        public int ToReplyID { get; set; }
        public int Active { get; set; }
        public int UserID { get; set; }

        public string ToReplyUserName { get; set; }
        
    }
}