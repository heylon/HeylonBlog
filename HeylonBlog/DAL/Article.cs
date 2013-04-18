using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using IDAL;
namespace DAL
{
    class Article:IArticle
    {
        HeylonBlogEntities blogEn;
        public Article()
        {
            blogEn = new HeylonBlogEntities();
        }
        public List<Model.Article> GetAll(int page,int pageSize)
        {
            var articleList = blogEn.Articles.AsQueryable();
            var mylist = from a in articleList
                         where a.Active == 1
                         orderby a.IsTop descending, a.SortID descending, a.CreateDate descending
                         select a;
            return mylist.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        }

        public Model.Article GetSingle(int id)
        {
            var article = blogEn.Articles.Single(a => a.ArticleID == id);
            return article;
        }

        public void Read(int id)
        {
            var article = blogEn.Articles.Single(a => a.ArticleID == id);
            article.ReadNum++;
            blogEn.SaveChanges();
        }
        public int SubmitReply(Model.ArticleReply model)
        {

            blogEn.ArticleReplies.Add(model);
            return blogEn.SaveChanges();
        }

        public ICollection<Model.Category> GetCategory()
        {
            return blogEn.Categories.Where(c => c.Active == 1).ToList();
        }

        public ICollection<Model.Tag> GetTag()
        {
            return blogEn.Tags.Where(t => t.Active == 1).ToList();
        }




    }
}
