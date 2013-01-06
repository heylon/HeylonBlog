using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL
{
    public interface IConfig
    {
        ICollection<Model.Section> GetSections();
        ICollection<Model.Article> GetArticleForNew(int num);
    }
}
