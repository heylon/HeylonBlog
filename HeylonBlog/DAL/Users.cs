using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IDAL;
using Model;


namespace DAL
{
    public class Users : IUsers
    {
        HeylonBlogEntities blogEn;
        public Users()
        {
            blogEn = new HeylonBlogEntities();
        }
        public bool Login(string username, string password)
        {

            if (blogEn.Users.Any(u => u.LoginName == username && u.Password == password && u.Active == 1))
            {
                var user = blogEn.Users.Single(u => u.LoginName == username && u.Password == password);
                HttpContext.Current.Session["user"] = user;
                return true;
            }
            return false;

        }
    }
}
