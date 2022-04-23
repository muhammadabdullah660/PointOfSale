using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using PointAndSaleApp.UI;
using System.IO;

namespace PointAndSaleApp.DL
{
    class MUserDL
    {
        private static List<MUser> usersList = new List<MUser>();

        public static void addUserIntoList (MUser user)
        {
            usersList.Add(user);
        }
        public static MUser isCustomerPresent (string customerName)
        {
            foreach (MUser myCustomer in usersList)
            {
                if (myCustomer.getUserName() == customerName && myCustomer.getUserRole() == "user")
                {
                    return myCustomer;
                }
            }
            return null;
        }
        public static MUser isValid (MUser user)
        {
            foreach (MUser storedUser in usersList)
            {
                if (storedUser.getUserName() == user.getUserName() &&
                storedUser.getUserPassword() == user.getUserPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static bool loadFromFile (string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string userName = splittedRecord[0];
                    string userPassword = (splittedRecord[1]);
                    string userRole = (splittedRecord[2]);
                    MUser M = new MUser(userName , userPassword , userRole);
                    addUserIntoList(M);
                    
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeIntoFile (string path , MUser M)
        {

            StreamWriter f = new StreamWriter(path , true);

            f.WriteLine(M.getUserName() + "," + M.getUserPassword() + "," + M.getUserRole());
            f.Flush();
            f.Close();
        }
    }
}
