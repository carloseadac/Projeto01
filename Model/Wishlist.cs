using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;

namespace Model
{
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        private Client client;
        private List<Product> products = new List<Product>();
        List<WishListDTO> wishListDTO = new List<WishListDTO>();
        //construtor
        public WishList(Client client)
        {
             this.client = client;
        }
        public WishList(){
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
        public void setProducts(List<Product> products)
        {
            this.products = products;
        }

        //set
        public void addProductToWishList(Product product)
        {
            if (!getProducts().Contains(product))
            {
                this.products.Add(product);
            }
        }
        public void setClient(Client client)
        {
            this.client = client;
        }

        //interface
        public bool validateObject()//WishList obj)
        {
            //if(obj.products == null) return false;
            //if(obj.client == null) return false; 
            return true;
        }
        public static WishList convertDTOToModel(WishList obj){
            return new WishList(obj.client);
        }


        public int save(int client, int prod)
        {
            var id = 0;

            using(var context = new DaoContext())
            {
                var clientDAO = context.clients.Where(c => c.id == client).Single();
                var productDAO = context.products.Where(c => c.id == prod).Single();
                
                var wl = new DAO.WishList{
                    client = clientDAO,
                    product = productDAO
                };

                context.wishLists.Add(wl);
                context.Entry(wl.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wl.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = wl.id;
            }
            return id;
                
                
        }

        public void update(WishListDTO obj)
        {

        }

        public static int findId(string document){
            using(var context = new DaoContext()){
                var client = context.clients.FirstOrDefault(s => s.document == document);
                return client.id;
            }
        }

        public List<WishListDTO> getAll()
        {        
            return this.wishListDTO;      
        }
        public WishListDTO convertModelToDTO()
        {
            var wishListDTO = new WishListDTO();
            wishListDTO.client = this.client.convertModelToDTO();

            foreach(var prod in this.products){
                wishListDTO.products.Add(prod.convertModelToDTO());
            }
            return wishListDTO;
        }

    
        public static WishList convertDTOToModel(WishListDTO obj)
        {

            var wishList = new WishList();

            wishList.setClient(Client.convertDTOToModel(obj.client));

            List<Product> products = new List<Product>();
            foreach (ProductDTO prod in obj.products)
            {
                products.Add(Product.convertDTOToModel(prod));
            }

            wishList.setProducts(products);

            return wishList;
        }
        public void delete(){
            using (var context = new DaoContext()){

                foreach(var prod in this.products){
                    var client = context.wishLists.FirstOrDefault(i => i.client.document == this.client.getDocument() && i.product.bar_code == prod.getBarCode());
                    context.wishLists.Remove(client);
                    context.SaveChanges();
                    } 
            }
        }

        public static string removeWishList(int  id){
            using(var context = new DaoContext())
            {
                var wishList = context.wishLists.FirstOrDefault(w => w.id == id);
                context.Remove(wishList);  
                context.SaveChanges();
                return " foi removido!";
            }
        }

        public WishListDTO findById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
