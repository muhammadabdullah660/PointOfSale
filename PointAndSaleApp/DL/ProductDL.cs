using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
using System.IO;
namespace PointAndSaleApp.DL
{
    class ProductDL
    {
        private static List<Product> productList = new List<Product>();
        public static void addProductIntoList (Product newProduct)
        {
            productList.Add(newProduct);
        }
        public static List<Product> getProducts ()
        {
            return productList;
        }
        public static Product isProductExist (string name)
        {
            foreach (Product item in productList)
            {

                if (name == item.getName())
                {
                    return item;
                }
            }
            return null;
        }
        public static Product highest ()
        {
            Product highestProduct = productList.OrderByDescending(item => item.getPrice()).First();
            return highestProduct;
        }
        public static List<Product> productsToOrder ()
        {
            List<Product> productsToBuyList = productList.Where(item => item.getQuantity() < item.getMinQuantity()).ToList();
            return productsToBuyList;
        }
        public static Product searchProduct (string name)
        {
            foreach (Product item in productList)
            {
                if (name == item.getName())
                {
                    return item;
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
                    string name = splittedRecord[0];
                    string category = (splittedRecord[1]);
                    int price = int.Parse(splittedRecord[2]);
                    int stockQuantity = int.Parse(splittedRecord[3]);
                    int minStockQ = int.Parse(splittedRecord[4]);
                    float tax = float.Parse(splittedRecord[5]);
                    Product p = new Product(name , category , price , stockQuantity , minStockQ);
                    addProductIntoList(p);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeIntoFile (string path , Product p)
        {

            StreamWriter f = new StreamWriter(path , true);

            f.WriteLine(p.getName() + "," + p.getCategory() + "," + p.getPrice() + "," + p.getQuantity() + "," + p.getMinQuantity() + "," + p.getTax());
            f.Flush();
            f.Close();
        }

    }
}
