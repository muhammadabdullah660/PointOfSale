using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using PointAndSaleApp.DL;
namespace PointAndSaleApp.UI
{
    class ProductUI
    {
        public static int adminMenu ()
        {
            int op;
            Console.WriteLine("DEPARTMENTAL STORE");
            Console.WriteLine("CHOOSE ONE OF THE FOLLOWING OPTIONS");
            Console.WriteLine("1-Add Products");
            Console.WriteLine("2-View All Products");
            Console.WriteLine("3-Product With Highest Unit Price");
            Console.WriteLine("4-View Sales Tax of All Products");
            Console.WriteLine("5-Products To be Added");
            Console.WriteLine("6-EXIT");
            op = int.Parse(Console.ReadLine());
            while (op > 6 || op < 1)
            {
                Console.WriteLine("Invalid Input\nEnter Again");
                op = int.Parse(Console.ReadLine());

            }
            return op;
            Console.Read();
        }
        public static Product addProduct ()
        {
            string name;
            string category;
            int price;
            int stockQuantity;
            int minStockQ;
            Console.WriteLine("Enter Product Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter Category Name");
            category = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Quantity");
            stockQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minimum Stock Quantity");
            minStockQ = int.Parse(Console.ReadLine());
            Product newProduct = new Product(name , category , price , stockQuantity , minStockQ);
            return newProduct;
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
        public static void viewProductWithHighestPrice ()
        {
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY");
            Product item = ProductDL.highest();
            Console.WriteLine($"{item.name}\t{item.category}\t{item.price}\t{item.stockQuantity}\t{item.minStockQ}");
        }
        public static void viewSalesTax ()
        {
            List<Product> productsList = ProductDL.returnProducts();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY\tSALES TAX");
            foreach (Product item in productsList)
            {
                Console.WriteLine($"{item.name}\t{item.category}\t{item.price}\t{item.stockQuantity}\t{item.minStockQ}\t{(item.tax * item.price) + item.price}");
            }
        }
        public static void lessThanThresholdProducts ()
        {
            List<Product> productsToBuyList = ProductDL.productsToOrder();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCKQUANTITY\tMINIMUNSTOCKQUANTITY\tSALESTAX");
            foreach (Product item in productsToBuyList)
            {
                Console.WriteLine($"{item.name}\t{item.category}\t{item.price}\t{item.stockQuantity}\t{item.minStockQ}");
            }
        }
    }
}
