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
    
    public partial class Category
    {
        public Category()
        {
            this.ArticleCategories = new HashSet<ArticleCategory>();
        }
    
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDesc { get; set; }
        public int Active { get; set; }
    
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual Category Category1 { get; set; }
        public virtual Category Category2 { get; set; }
    }
}
