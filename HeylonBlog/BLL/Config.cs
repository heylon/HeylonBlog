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
                string content = "";
                int i = 1;
                switch (section.SectionCode)
                {

                    case "NewArticle":

                        content += "<ul>";
                        foreach (var article in dal.GetArticleForNew(10))
                        {
                            content += "<li><a href=\"/Blog/Show/" + article.ArticleID + "\">" + (i++) + ". " + article.ArticleTitle + " (" + article.CreateDate.ToString("yyyy年MM月dd日") + ")" + "</a></li>";
                        }
                        content += "</ul>";
                        section.SectionContent = content;
                        break;
                    case "TopArticle":
                        content += "<ul>";
                        foreach (var article in dal.GetTopArticle(10))
                        {
                            content += "<li><a href=\"/Blog/Show/" + article.ArticleID + "\" >" + (i++) + ". " + article.ArticleTitle + " (" + article.ReadNum + ")" + "</a></li>";
                        }
                        content += "</ul>";
                        section.SectionContent = content;
                        break;
                    case "NewReply":
                        content += "newReply";
                       
                        section.SectionContent = content;
                        break;
                    default:

                        break;
                }
            }
            return list;
        }
    }
}
