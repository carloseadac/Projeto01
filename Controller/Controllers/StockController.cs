using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("stock")]

public class StockController : ControllerBase{
    [HttpPost]
    [Route("add")]
    public object addProductToStock([FromBody] StocksDTO stocks){
        var stockModel = Model.Stocks.convertDTOToModel(stocks);
        var storeId = Model.Store.findId(stockModel.getStore().getCNPJ());
        var productId = Model.Product.findId(stockModel.getProduct().getBarCode());
        
        var id = stockModel.save(storeId, productId, stockModel.getQuantity(), stockModel.getUnitPrice());

        return new{
            id = id,
            quantity = stocks.quantity,
            unit_price = stocks.unit_price,
            product = stocks.ProductDTO,
            store = stocks.StoreDTO
        };
    }

    
    [HttpPut]
    [Route("update")]
    public Object update([FromBody]StocksDTO stocksDTO){
    Model.Stocks.update(stocksDTO);
        return new{
            status = "ok",
            mensagem = "deu boa"
        };
    }   
    
}