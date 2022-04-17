using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class MUser
    {
        public string userName;
        public string userPassword;
        public string userRole;
        public MUser (string userName , string userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = "NA";
        }
        public MUser (string userName , string userPassword , string userRole)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }
        public bool isAdmin ()
        {
            if (this.userRole == "Admin")
            {
                return true;
            }
            return false;
        }

    }
}
