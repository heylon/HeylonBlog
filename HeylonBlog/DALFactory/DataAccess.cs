using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using IDAL;
using System.Reflection;


namespace DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess() { }

        public static IArticle CreateArticle()
        {
            string className = path + ".Article";
            return (IArticle)Assembly.Load(path).CreateInstance(className);
        }

        public static IUsers CreateUsers()
        {
            string className = path + ".Users";
            return (IUsers)Assembly.Load(path).CreateInstance(className);
        }

        public static IConfig CreateConfig()
        {
            string className = path + ".Config";
            return (IConfig)Assembly.Load(path).CreateInstance(className);
        }
    }
}
