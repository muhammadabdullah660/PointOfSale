using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class MUser
    {
        private string userName;
        private string userPassword;
        private string userRole;
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
        public string getUserName ()
        {
            return userName;
        }
        public string getUserPassword ()
        {
            return userPassword;
        }
        public string getUserRole ()
        {
            return userRole;
        }
        public void setUserName (string userName)
        {
            this.userName = userName;
        }
        public void setUserPassword (string userPassword)
        {
            this.userPassword = userPassword;
        }
        public void setUserRole (string userRole)
        {
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
