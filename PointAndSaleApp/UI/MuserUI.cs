using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using PointAndSaleApp.DL;
namespace PointAndSaleApp.UI
{
    class MuserUI
    {
        public static MUser signUp ()
        {
            Console.WriteLine("Enter UserName:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string userPassword = Console.ReadLine();
            Console.WriteLine("Enter Role:");
            string userRole = Console.ReadLine();

            MUser user = new MUser(userName , userPassword , userRole);
            return user;

        }

        public static MUser signInMenu ()
        {
            Console.WriteLine("Enter UserName:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string userPassword = Console.ReadLine();
            MUser user = new MUser(userName , userPassword);
            return user;
        }

        public static MUser SignIn ()
        {
            MUser user = signInMenu();
            MUser user1 = MUserDL.isValid(user);
            return user1;
        }

    }
}
