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
    public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
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

        public bool validateObject()//Stocks obj)
        {
            //if(obj.quantity == 0) return false;
            //if(obj.product == null) return false; 
            //if(obj.store == null) return false;
            return true;
        }

            public static Stocks convertDTOToModel(StocksDTO obj)
        {
            
            var stocks = new Stocks();
            stocks.quantity(obj.quantity);
            stocks.unit_price(obj.unit_price);
            stocks.store =  Store.convertDTOToModel(obj.store);
            stocks.product=Product.convertDTOToModel(obj.product);

            return stocks;
            
        }

         public void delete(StocksDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using(var context = new DAOContext())
            {
                var stocks = new DAO.stocks{
                    quantity = this.quantity,
                    unit_price = this.unit_price,
                    store = this.store,
                    product = this.product
                };

                context.Stocks.Add(stocks);

                context.SaveChanges();

                id = stocks.id;

            }
            return id;
        }

        public void update(StocksDTO obj)
        {

        }

        public StocksDTO findById(int id)
        {

            return new StocksDTO();
        }

        public List<StocksDTO> getAll()
        {        
            return this.stocksDTO;      
        }

    
        public StocksDTO convertModelToDTO()
        {
            var stocksDTO = new StocksDTO();

            stocksDTO.quantity = this.quantity;

            stocksDTO.unitPrice = this.unit_price;

            stocksDTO.store = this.store;

            stocksDTO.product = this.product;

            return stocksDTO;
        }




    }
}
