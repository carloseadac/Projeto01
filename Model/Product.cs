using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
    {
        //Declaração das variáveis
        private String name;
        //private Double unit_price;
        private String bar_code;

        private string image;
        private string description;


        List<ProductDTO> productDTO = new List<ProductDTO>();

        

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
        public string getImage()
        {
            return image;
        }
        public string getDescription()
        {
            return description;
        }
        public void setImage(string image)
        {
            this.image = image;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        
        

        public static void update(ProductDTO productDTO)
        {
            using (var context = new DaoContext()){
                var product = context.products.FirstOrDefault(a => a.bar_code == productDTO.bar_code);

                if(product != null){
                    if(productDTO.name != null){
                        product.name = productDTO.name;
                    }
                }
                context.SaveChanges();
            }
        }

        public ProductDTO findById(int id){
            return new ProductDTO();
        }

        public List<ProductDTO> getAll()
        {
            return this.productDTO;
        }

        public ProductDTO convertModelToDTO(){
            var productDTO = new ProductDTO();
            productDTO.name = this.name;
            productDTO.bar_code = this.bar_code;
            productDTO.image = this.image;
            productDTO.description = this.description;
            
            return productDTO;
        }
        
        

        public bool validateObject()
        {
            if(this.getName == null) return false;                      
            if(this.getBarCode == null) return false;
            return true;
        }

        public int save()
        {
             var id = 0;

            using(var context = new DaoContext())
            {
                var product = new DAO.Product{
                    name = this.name,
                    bar_code = this.bar_code,
                    image = this.image,
                    description = this.description
                };

                context.products.Add(product);
                context.SaveChanges();
                id = product.id;
            }
            return id;
        }

        public static Product convertDTOToModel(ProductDTO obj)
        {

            Product product = new Product();

            product.setBarCode(obj.bar_code);
            product.setName(obj.name);
            product.setDescription(obj.description);
            product.setImage(obj.image);

            return product;
        }

        public static void delete(ProductDTO productDTO)
        {
            using (var context = new DaoContext()){
                var produto = context.products.FirstOrDefault(i => i.bar_code == productDTO.bar_code);

                context.products.Remove(produto);
                context.SaveChanges();
            }
        }
        public static List<object> getProducts()
        {
            List<object> produtos = new List<object>();

            using(var context = new DaoContext()){

                var stocks = context.stocks.Include(s => s.product).Include(s => s.store).ToList();
                foreach(var stock in stocks)
                {
                    produtos.Add(new
                    {
                        id = stock.product.id,
                        name = stock.product.name,
                        bar_code = stock.product.bar_code,
                        image = stock.product.image,
                        description = stock.product.description,
                        price = stock.unit_price,
                        idStocks = stock.id,
                        idStore = stock.store.id
                    });
                }
            }
            return produtos;
        }

        public static int findId(string bar_code){
            using(var context = new DaoContext()){
                var product = context.products.FirstOrDefault(s => s.bar_code == bar_code);
                return product.id;
            }
        }
        public static int find(ProductDTO productDTO){
            using (var context = new DaoContext()){
                var produto = context.products.FirstOrDefault(s => s.bar_code == productDTO.bar_code);

                return produto.id;
            }
        }
        public int getID()
        {
            using (var context = new DaoContext())
            {
                var product = context.products.FirstOrDefault(p => p.bar_code == this.bar_code);
                return product.id;
            }
        }
        

    }
        
}
