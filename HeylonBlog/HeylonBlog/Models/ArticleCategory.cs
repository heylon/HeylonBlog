//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeylonBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArticleCategory
    {
        public int ArticleCateGoryID { get; set; }
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public int Active { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
