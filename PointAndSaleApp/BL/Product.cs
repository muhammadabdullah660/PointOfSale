using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class Product
    {
        public string name;
        public string category;
        public int price;
        public int stockQuantity;
        public int minStockQ;
        public float tax;
        public Product ()
        {
            name = "abc";
            category = "xyz";
            price = 1;
            stockQuantity = 1;
            minStockQ = 1;

        }
        public Product (string name , string category , int price , int stockQuantity , int minStockQ)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.minStockQ = minStockQ;
            itemTax();
        }
        public Product (Product p)
        {
            this.name = p.name;
            this.category = p.category;
            this.price = p.price;
            this.stockQuantity = p.stockQuantity;
            this.minStockQ = p.minStockQ;

        }
        public void itemTax ()
        {
            if (this.category == "Grocery")
            {
                this.tax = 0.1F;
            }
            else if (this.category == "Fruit")
            {
                this.tax = 0.05F;
            }
            else
            {
                this.tax = 0.15F;
            }
        }
        public void changeQuantity (int quantity)
        {
            this.stockQuantity -= quantity;
        }



    }
}
