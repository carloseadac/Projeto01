using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WishList
    {
        private Client client;

        private List<Product> products = new List<Product>();

        //construtor
        public WishList(Client client)
        {
            this.client = client;
        }

        public Client getClient()
        {
            return client;
        }
        public List<Product> getProducts()
        {
            return products;
        }
        public void addProductToWishList(Product product)
        {
            products.Add(product);
        }
        
    }
}
