using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using PointAndSaleApp.DL;
namespace PointAndSaleApp.UI
{
    class CustomerUI
    {
        public static int customerMenu ()
        {
            int op;
            Console.WriteLine("DEPARTMENTAL STORE");
            Console.WriteLine("CHOOSE ONE OF THE FOLLOWING OPTIONS");
            Console.WriteLine("1-View all products");
            Console.WriteLine("2-Buy the products");
            Console.WriteLine("3-Generate invoice");
            Console.WriteLine("4-EXIT");
            op = int.Parse(Console.ReadLine());
            while (op > 4 || op < 1)
            {
                Console.WriteLine("Invalid Input\nEnter Again");
                op = int.Parse(Console.ReadLine());

            }
            return op;
        }
        public static void viewProducts ()
        {
            List<Product> productsList = ProductDL.returnProducts();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY");
            foreach (Product item in productsList)
            {
                Console.WriteLine($"{item.name}\t{item.category}\t{item.price}\t{item.stockQuantity}\t{item.minStockQ}");
            }
        }
        public static void buyProduct ()
        {
            Console.WriteLine("Enter number of Products you want to buy:");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < count ; i++)
            {
                Console.WriteLine("Enter Name of the Product :");
                string name = Console.ReadLine();
                Product product = ProductDL.searchProduct(name);
                if (product != null)
                {

                    Console.WriteLine("Enter the quantity of product :");
                    int productQuantity = int.Parse(Console.ReadLine());
                    if (product.stockQuantity > productQuantity)
                    {
                        product.changeQuantity(productQuantity);
                        Product p1 = new Product(product);
                        Customer.customerQuantity(p1 , productQuantity);
                        Customer.addProductIntoListCustomer(p1);
                    }
                    else
                    {
                        Console.WriteLine("Not Enough Stock Available");
                        Console.ReadKey();
                    }

                }
            }
        }
        public static void generateInvoice ()
        {
            /*Console.WriteLine($"CUSTOMER NAME : {cust.customerName}");
            Console.WriteLine("------------------------------");*/
            List<Product> productsList = Customer.purchaseProducts;
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tPURCHASE QUANTITY\tSALES TAX");
            foreach (Product item in productsList)
            {
                Console.WriteLine($"{item.name}\t{item.category}\t{item.price}\t{item.stockQuantity}\t{item.tax * 100}%");
            }
            Console.WriteLine("Total Bill : " + Customer.invoice());
            Console.ReadKey();
        }
    }
}
