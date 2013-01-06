using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DALFactory;
using IDAL;

namespace BLL
{
    public class Config
    {
        private static readonly IConfig dal = DataAccess.CreateConfig();

        public ICollection<Model.Section> GetSections()
        {
            ICollection<Model.Section> list = dal.GetSections();


            foreach (var section in list)
            {
                string content = "<ul>";
                switch (section.SectionCode)
                {

                    case "NewArticle":
                        foreach (var article in dal.GetArticleForNew(10))
                        {
                            content += "<li><a href=\"#\">" + article.ArticleTitle + "</a></li>";
                        }
                        content += "</ul>";
                        section.SectionContent = content;
                        break;
                    case "TopArticle":
                        section.SectionContent = "this is Top Article";
                        break;
                    default:

                        break;
                }
            }
            return list;
        }
    }
}
