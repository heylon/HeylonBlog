using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IDAL;
using DALFactory;

namespace BLL
{
    public class Users
    {
        private static readonly IUsers dal = DataAccess.CreateUsers();
        public Users()
        {
        }
        public bool Login(string username, string password)
        {
            return dal.Login(username, password);
        }
    }
}
