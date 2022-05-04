using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
        [HttpGet]
        public void allProduct(){

        }

        [HttpPost]
        [Route("create")]
        public Object createProduct([FromBody]ProductDTO productDTO){
                var product = Product.convertDTOToModel(productDTO);
                var id = product.save();
                return new{
                        name = productDTO.name,
                        bar_code = productDTO.bar_code,
                        id = id
                };
        }
        [HttpDelete]
        [Route("delete")]
        public void deleteProduct(ProductDTO product){
          //      Product.delete(product);
        }

        [HttpPut]
        [Route("put")]
        public void updateProduct(ProductDTO product){
              //  Product.update(product);
        }
}