using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointAndSaleApp.BL
{
    class Customer
    {
        private List<Product> purchaseProducts = new List<Product>();
        private MUser userId;
        public double bill;
        public Customer (MUser userId)
        {
            this.userId = userId;
        }
        public List<Product> getPurchaseProducts ()
        {
            return purchaseProducts;
        }
        public MUser getuserId ()
        {
            return userId;
        }
        public void customerQuantity (Product myProduct , int stockQuantity)
        {

            myProduct.setQuantity(stockQuantity);
        }
        public void addProductIntoListCustomer (Product newProduct)
        {
            purchaseProducts.Add(newProduct);
        }
        public double invoice ()
        {
            double bill = 0;
            foreach (Product item in purchaseProducts)
            {
                bill += item.getQuantity() * (item.getPrice() + (item.getTax()));
            }
            return bill;
        }
    }
}
