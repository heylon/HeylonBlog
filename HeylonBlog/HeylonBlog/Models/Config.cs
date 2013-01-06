using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeylonBlog.Models
{
    public class SectionShow
    {
        public SectionShow(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}