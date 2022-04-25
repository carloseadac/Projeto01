using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
using Interfaces;


namespace Model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
    {
        //Declaração das variáveis
        private String name;
        //private Double unit_price;
        private String bar_code;
        private Store store;


        public List<ProductDTO> productDTO = new List<ProductDTO>();

        public static Product convertDTOToModel(ProductDTO obj)
        {
            var product = new Product();
            product.setName(obj.name);
            product.setBarCode(obj.barCode);
            return product;
        }


        //construtor
        public Product()
        {

        }

        //Getters e Setters
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        // public double getUnitprice()
        // {
        //     return unit_price;
        // }
        // public void setUnitPrice(double unit_price)
        // {
        //     this.unit_price = unit_price;
        // }
        public string getBarCode()
        {
            return bar_code;
        }
        public void setBarCode(string bar_code)
        {
            this.bar_code = bar_code;
        }
        
        public void delete(ProductDTO obj){

        }

        public void update(ProductDTO obj){

        }

        public ProductDTO findById(int id){
            return new ProductDTO();
        }

        public List<ProductDTO> getAll(){
            return this.ProductDTO;
        }

        public ProductDTO convertModelToDTO(){
            var productDTO = new ProductDTO();
            productDTO.name = this.name;
            productDTO.barCode = this.barCode;
            productDTO.store = this.store.convertModelToDTO();
            return productDTO;
        }
        
        

        public bool validateObject()//Product obj)
        {
            //if(obj.name == null) return false;          
            //if(obj.unit_price == 0.0) return false;            
            //if(obj.bar_code == null) return false;
            return true;
        }

        public int save()
        {
            var id = 0;

            using(var context = new DAOContext())
            {
                var product = new DAO.Product{
                    name = this.name,
                    barCode = this.barCode,
                    store = this.store
             };

                context.Product.Add(product);
                context.SaveChanges();
                id = product.id;

            }
              return id;
        }
    }
}
