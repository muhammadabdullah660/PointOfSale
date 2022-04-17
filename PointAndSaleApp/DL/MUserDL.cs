using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using System.IO;

namespace PointAndSaleApp.DL
{
    class MUserDL
    {
        static List<MUser> usersList = new List<MUser>();

        public static void addUserIntoList (MUser user)
        {
            usersList.Add(user);
        }
        public static MUser isValid (MUser user)
        {
            foreach (MUser storedUser in usersList)
            {
                if (storedUser.userName == user.userName &&
                storedUser.userPassword == user.userPassword)
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static void readDataFromFile ()
        {
            string path = "Muser.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                string userName, userPassword, userRole;
                while ((line = file.ReadLine()) != null)
                {
                    userName = ParseRecord(line , 1);
                    userPassword = ParseRecord(line , 2);
                    userRole = ParseRecord(line , 3);
                    MUser user = new MUser(userName , userPassword , userRole);
                    addUserIntoList(user);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("No User Exists");
                Console.ReadKey();
            }
        }



        public static string ParseRecord (string line , int field)
        {
            int commacount = 1;
            string item = " ";
            for (int i = 0 ; i < line.Length ; i++)
            {
                if (line[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }

        public static void StoreUserintoList ()
        {
            string path = "Muser.txt";
            StreamWriter file = new StreamWriter(path , false);
            foreach (MUser storedUser in usersList)
            {
                file.WriteLine($"{storedUser.userName},{storedUser.userPassword},{storedUser.userRole}");
            }
            file.Flush();
            file.Close();
        }
    }
}
