using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using DALFactory;

namespace BLL
{
    public class Article
    {
        private static readonly IArticle dal = DataAccess.CreateArticle(); 
        public Article()
        {
        }

        public List<Model.Article> GetAll(int page,int pageSize)
        {
            return dal.GetAll(page,pageSize);
        }
        public Model.Article GetSingle(int id)
        {
            return dal.GetSingle(id);
        }
        public void Read(int id)
        {
            dal.Read(id);
        }
        public int SubmitReply(Model.ArticleReply model)
        {
            return dal.SubmitReply(model);
        }

        public ICollection<Model.Category> GetCategory()
        {
            return dal.GetCategory();
        }

        public ICollection<Model.Tag> GetTag()
        {
            return dal.GetTag();
        }
    }
}
