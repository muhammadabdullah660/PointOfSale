using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointAndSaleApp.BL;
namespace PointAndSaleApp.DL
{
    class ProductDL
    {
        public static List<Product> productList = new List<Product>();
        public static void addProductIntoList (Product newProduct)
        {
            productList.Add(newProduct);
        }
        public static List<Product> returnProducts ()
        {
            return productList;
        }
        public static Product highest ()
        {
            Product highestProduct = productList.OrderByDescending(item => item.price).First();
            return highestProduct;
        }
        public static List<Product> productsToOrder ()
        {
            List<Product> productsToBuyList = productList.Where(item => item.stockQuantity < item.minStockQ).ToList();
            return productsToBuyList;
        }
        public static Product searchProduct (string name)
        {
            foreach (Product item in productList)
            {
                if (name == item.name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
