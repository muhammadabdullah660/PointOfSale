using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PointAndSaleApp.BL;
namespace PointAndSaleApp.DL
{
    class CustomerDL
    {
        private static List<Customer> customersList = new List<Customer>();

        public static Customer isCustomerPresent (string customerName)
        {
            foreach (Customer myCustomer in customersList)
            {
                if (myCustomer.getuserId().getUserName() == customerName)
                {
                    return myCustomer;
                }
            }
            return null;
        }
        public static List<Customer> getcustomersList ()
        {
            return customersList;
        }
        public static void addIntoCustomerList (Customer cust)
        {
            customersList.Add(cust);
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
                    string name = splittedRecord[0];
                    int bill = int.Parse(splittedRecord[1]);
                    string[] splittedRecordPref = splittedRecord[2].Split(';');
                    MUser newUser = MUserDL.isCustomerPresent(name);
                    Customer cust = new Customer(newUser);
                    cust.bill = bill;
                    for (int i = 0 ; i < splittedRecordPref.Length ; i++)
                    {
                        Product d = ProductDL.isProductExist(splittedRecordPref[i]);
                        //   Console.WriteLine(splittedRecordPref[i]);
                        if (d != null)
                        {
                            cust.addProductIntoListCustomer(d);
                        }

                    }
                    addIntoCustomerList(cust);
                    //   Console.WriteLine(CustomerDL.getcustomersList().Count);

                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeIntoFile (string path)
        {
            StreamWriter f = new StreamWriter(path , false);
            foreach (Customer cust in customersList)
            {
                string name = "";
                for (int i = 0 ; i < cust.getPurchaseProducts().Count ; i++)
                {
                    if (i != cust.getPurchaseProducts().Count - 1)
                    {
                        name += cust.getPurchaseProducts()[i].getName() + ";";
                    }
                    else
                    {
                        name += cust.getPurchaseProducts()[i].getName();
                    }
                }
                f.WriteLine(cust.getuserId().getUserName() + "," + cust.invoice() + "," + name);
            }

            f.Flush();
            f.Close();
        }
    }
}
