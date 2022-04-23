using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class Product
    {
        private string name;
        private string category;
        private int price;
        private int stockQuantity;
        private int minStockQ;
        private float tax;
        public Product ()
        {
            name = "abc";
            category = "xyz";
            price = 1;
            stockQuantity = 1;
            minStockQ = 1;

        }
        public string getName ()
        {
            return name;
        }
        public string getCategory ()
        {
            return category;
        }
        public int getPrice ()
        {
            return price;
        }
        public int getQuantity ()
        {
            return stockQuantity;
        }
        public int getMinQuantity ()
        {
            return minStockQ;
        }
        public float getTax ()
        {
            return tax;
        }
        public void setName (string name)
        {
            this.name = name;
        }
        public void setCategory (string category)
        {
            this.category = category;
        }
        public void setPrice (int price)
        {
            this.price = price;
        }
        public void setQuantity (int stockQuantity)
        {
            this.stockQuantity = stockQuantity;
        }
        public void setMinQuantity (int minStockQ)
        {
            this.minStockQ = minStockQ;
        }
        /*   public float setTax ()
           {
               return tax;
           }*/

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
                this.tax = (0.1F * price) * stockQuantity;
            }
            else if (this.category == "Fruit")
            {
                this.tax = (0.05F * price) * stockQuantity;
            }
            else
            {
                this.tax = (0.15F * price) * stockQuantity;
            }
        }
        public void changeQuantity (int quantity)
        {
            this.stockQuantity -= quantity;
        }



    }
}
