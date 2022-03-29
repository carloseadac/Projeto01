using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wishlist
    {
        private Client client;

        private List<Product> products;

        public void addProductToWishList(Product product)
        {
            products.Add(product);
        }
        
    }
}
