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
            List<Product> productsList = ProductDL.getProducts();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY");
            foreach (Product item in productsList)
            {
                string name = item.getName();
                string category = item.getCategory();
                int price = item.getPrice();
                int stockQuantity = item.getQuantity();
                int minStockQ = item.getMinQuantity();
                Console.WriteLine($"{name}\t{category}\t{price}\t{stockQuantity}\t{minStockQ}");
            }
        }
        public static void viewProductWithHighestPrice ()
        {
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY");
            Product item = ProductDL.highest();
            string name = item.getName();
            string category = item.getCategory();
            int price = item.getPrice();
            int stockQuantity = item.getQuantity();
            int minStockQ = item.getMinQuantity();
            Console.WriteLine($"{name}\t{category}\t{price}\t{stockQuantity}\t{minStockQ}");
        }
        public static void viewSalesTax ()
        {
            List<Product> productsList = ProductDL.getProducts();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCK QUANTITY\tMINIMUN STOCK QUANTITY\tSALES TAX");
            foreach (Product item in productsList)
            {
                string name = item.getName();
                string category = item.getCategory();
                int price = item.getPrice();
                int stockQuantity = item.getQuantity();
                int minStockQ = item.getMinQuantity();
                float tax = item.getTax();
                Console.WriteLine($"{name}\t{category}\t{price}\t{stockQuantity}\t{minStockQ}\t{(tax) + price}");
            }
        }
        public static void lessThanThresholdProducts ()
        {
            List<Product> productsToBuyList = ProductDL.productsToOrder();
            Console.WriteLine("NAME\tCATEGORY\tPRICE\tSTOCKQUANTITY\tMINIMUNSTOCKQUANTITY\tSALESTAX");
            foreach (Product item in productsToBuyList)
            {
                string name = item.getName();
                string category = item.getCategory();
                int price = item.getPrice();
                int stockQuantity = item.getQuantity();
                int minStockQ = item.getMinQuantity();
                Console.WriteLine($"{name}\t{category}\t{price}\t{stockQuantity}\t{minStockQ}");
            }
        }
    }
}
