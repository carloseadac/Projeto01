using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Stocks : IValidateDataObject<Stocks>
    {
        //declarando variáveis
        private int quantity;
        private Product product;
        private Store store;
        private double unit_price;

        //construtor
        
        //getters e setters
        public double getUnitPrice()
        {
            return unit_price;
        }
        public void setUnitPrice(double unit_price)
        {
            this.unit_price = unit_price;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public Product getProduct()
        {
            return product;
        }
        public void setProduct(Product product)
        {
            this.product = product;
        }
        public Store getStore()
        {
            return store;
        }
        public void setStore(Store store)
        {
            this.store = store;
        }

        public bool validateObject(Stocks obj)
        {
            if(obj.quantity == 0) return false;
            if(obj.product == null) return false; 
            if(obj.store == null) return false;
            return true;
        }
    }
}
