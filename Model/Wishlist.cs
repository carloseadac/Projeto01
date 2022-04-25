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
        List<Product> products = new List<Product>();

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

        public void delete(WishListDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using(var context = new DaoContext())
            {
                var clientDAO = context.clients.Where(c => c.document == clientDoc).Single();
                var wl = new DAO.WishList{
                    client = clientDAO
                };

                context.wishLists.Add(wl);
                context.Entry(wl.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = wl.id;
            }
            return id;
                
                
        }

        public void update(WishListDTO obj)
        {

        }

        public WishListDTO findById(int id)
        {

            return new WishListDTO();
        }

        public List<WishListDTO> getAll()
        {        
            return this.wishListDTO;      
        }

    
        public WishListDTO convertModelToDTO()
        {
            var wishListDTO = new WishListDTO();

            wishListDTO.client = this.client.convertModelToDTO();

            wishListDTO.listaProdutos = this.listaProdutos;

            return wishListDTO;
        }
    }
}
