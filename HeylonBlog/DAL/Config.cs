using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using Model;
namespace DAL
{
   public  class Config:IConfig
    {
       HeylonBlogEntities blogEn;

       public Config()
       {
           blogEn = new HeylonBlogEntities();
       }

       public ICollection<Model.Section> GetSections()
       {
           return blogEn.Sections.OrderByDescending(s => s.SortID).ToList();
       }

       public ICollection<Model.Article> GetArticleForNew(int num)
       {
           var article = blogEn.Articles
               .Where(a => a.Active == 1)
               .OrderByDescending(a => a.CreateDate)
               .Take(num)
               .ToList();
           return article;
       }

       public ICollection<Model.Article> GetTopArticle(int num)
       {
           var article = blogEn.Articles
               .Where(a => a.Active == 1)
               .OrderByDescending(a => a.ReadNum)
               .OrderByDescending(a => a.CreateDate)
               .Take(num)
               .ToList();
           return article;
       }

    }
}
