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
        private Double quantity;
        private Product product;
        private Store store;
        private double unit_price;
        List<StocksDTO> stocksDTO = new List<StocksDTO>();

        //construtor
        public Stocks() { }

        //getters e setters
        public double getUnitPrice()
        {
            return unit_price;
        }
        public void setUnitPrice(double unit_price)
        {
            this.unit_price = unit_price;
        }
        public Double getQuantity()
        {
            return quantity;
        }
        public void setQuantity(double quantity)
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

         public void delete(StocksDTO obj){

        }

        public int save(int store, int product, int quantity, double unit_price)
        {
            var id = 0;

            

            using(var context = new DaoContext())
            {
                var storeDTO = context.stores.Where(c => c.id == store).Single();
                var productDTO = context.products.Where(c => c.id == product).Single();
                var stocks = new DAO.Stocks{
                    quantity = quantity,
                    unit_price = unit_price,
                    store = storeDTO,
                    product = productDTO
                };

                context.stocks.Add(stocks);
                //context.Entry(stocks.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                //context.Entry(stocks.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = stocks.id;
            }
            return id;
        }

        public void update(StocksDTO obj){

        }

        public StocksDTO findById(int id){
            return new StocksDTO();
        }

        public List<StocksDTO> getAll(){
            return this.stocksDTO;
        }

        public StocksDTO convertModelToDTO(){
            var stocksDTO = new StocksDTO();
            stocksDTO.quantity = this.quantity;
            stocksDTO.unit_price = this.unit_price;
            stocksDTO.ProductDTO = this.product.convertModelToDTO();
            stocksDTO.StoreDTO = this.store.convertModelToDTO();

            return stocksDTO;
        }

        public static Stocks convertDTOToModel(StocksDTO obj){
            Stocks stock = new Stocks();

            stock.setQuantity(obj.quantity);
            stock.setUnitPrice(obj.unit_price);
            stock.setProduct(Product.convertDTOToModel(obj.ProductDTO));
            stock.setStore(Store.convertDTOToModel(obj.StoreDTO));
            
            return stock;
        }



    }
}
