using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class WishList : IValidateDataObject
    {
        private Client client;

        private List<Product> products = new List<Product>();

        //construtor
        public WishList(Client client)
        {
            this.client = client;
        }

        //getters
        public Client getClient()
        {
            return client;
        }
        public List<Product> getProducts()
        {
            return products;
        }

        //set
        public void addProductToWishList(Product product)
        {
            products.Add(product);
        }

        //interface
        public bool validateObject()//WishList obj)
        {
            //if(obj.products == null) return false;
            //if(obj.client == null) return false; 
            return true;
        }
    }
}
