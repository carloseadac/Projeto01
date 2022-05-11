using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
        [HttpGet]
        [Route("getall")]
        public object allProduct(){
                var produtos = Model.Product.getProducts();
                return produtos; 

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
        /*
        [Route("delete")]
        public object deleteProduct([FromBody]ProductDTO productDTO){
          var produto = Model.Product.convertDTOToModel(productDTO);
                produto.dele();

                return new {
                        status = "ok",
                        mensagem = "excluido"
                };

        }
        */
        [HttpPut]
        [Route("update")]
        public Object updateProduct([FromBody] ProductDTO productDTO){
                Model.Product.update(productDTO);
                return new{
                        status = "ok",
                        mensagem = "deu boa"
                };
         }
}