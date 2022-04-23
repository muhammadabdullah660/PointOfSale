using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using PointAndSaleApp.UI;
using PointAndSaleApp.DL;

namespace PointAndSaleApp
{
    class Program
    {
        static void Main ()
        {
            MUserDL.loadFromFile("MUser.txt");
            ProductDL.loadFromFile("prod.txt");
            CustomerDL.loadFromFile("cust.txt");
            int op = 0;
            while (op < 3)
            {
                op = mainMenu();
                clearScreen();

                if (op == 1)
                {
                    MUser newUser = MuserUI.SignIn();
                    clearScreen();
                    if (newUser != null)
                    {
                        if (newUser.isAdmin())
                        {
                            int op1 = 0;
                            while (op1 < 6)
                            {
                                op1 = ProductUI.adminMenu();
                                clearScreen();
                                if (op1 == 1)
                                {
                                    Product newProduct = ProductUI.addProduct();
                                    ProductDL.addProductIntoList(newProduct);
                                    ProductDL.storeIntoFile("prod.txt" , newProduct);
                                    clearScreen();
                                }
                                else if (op1 == 2)
                                {

                                    ProductUI.viewProducts();
                                    clearScreen();
                                }
                                else if (op1 == 3)
                                {

                                    ProductUI.viewProductWithHighestPrice();
                                    clearScreen();
                                }
                                else if (op1 == 4)
                                {

                                    ProductUI.viewSalesTax();
                                    clearScreen();
                                }
                                else if (op1 == 5)
                                {

                                    ProductUI.lessThanThresholdProducts();
                                    clearScreen();
                                }
                            }
                        }
                        else
                        {

                            Customer myCust = CustomerDL.isCustomerPresent(newUser.getUserName());
                            int op2 = 0;
                            clearScreen();

                            while (op2 < 4)
                            {
                                op2 = CustomerUI.customerMenu();
                                clearScreen();
                                if (op2 == 1)
                                {

                                    CustomerUI.viewProducts();
                                    clearScreen();
                                }
                                else if (op2 == 2)
                                {

                                    CustomerUI.buyProduct(myCust);
                                    clearScreen();
                                }
                                else if (op2 == 3)
                                {

                                    CustomerUI.generateInvoice(myCust);
                                    clearScreen();
                                }
                            }
                        }
                    }
                }
                else if (op == 2)
                {
                    MUser newUser = MuserUI.signUp();
                    MUserDL.addUserIntoList(newUser);
                    MUserDL.storeIntoFile("MUser.txt" , newUser);
                    clearScreen();

                }

            }
            CustomerDL.storeIntoFile("cust.txt");
        }

        static int mainMenu ()
        {
            int op;
            Console.WriteLine("DEPARTMENTAL STORE");
            Console.WriteLine("CHOOSE ONE OF THE FOLLOWING OPTIONS");
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("3.Exit");
            op = int.Parse(Console.ReadLine());
            return op;
        }


        static void clearScreen ()
        {
            //Console.WriteLine(CustomerDL.getcustomersList().Count);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
