//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.ArticleReplies = new HashSet<ArticleReply>();
            this.Articles = new HashSet<Article>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public int Active { get; set; }
    
        public virtual ICollection<ArticleReply> ArticleReplies { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
