using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace IDAL
{
    public interface IArticle
    {
        List<Model.Article> GetAll(int page,int pageSize);
        Model.Article GetSingle(int id);
        void Read(int id);
        int SubmitReply(Model.ArticleReply model);
        
    }
}
