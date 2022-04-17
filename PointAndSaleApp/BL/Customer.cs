using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class Customer
    {
        public static List<Product> purchaseProducts = new List<Product>();

        public static void customerQuantity (Product myProduct , int quantity)
        {
            myProduct.stockQuantity = quantity;
        }
        public static void addProductIntoListCustomer (Product newProduct)
        {
            purchaseProducts.Add(newProduct);
        }
        public static double invoice ()
        {
            double bill = 0;
            foreach (Product item in purchaseProducts)
            {
                bill += item.stockQuantity * (item.price + (item.tax * item.price));
            }
            return bill;
        }
    }
}
