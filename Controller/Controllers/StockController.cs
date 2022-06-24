using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("stock")]

public class StockController : ControllerBase{
    [HttpPost]
    [Route("add")]
    public object addProductToStock([FromBody] StocksDTO obj){

        Stocks stocksModel = Model.Stocks.convertDTOToModel(obj);
        var id = stocksModel.save(stocksModel.getStore().getID(), stocksModel.getProduct().getID(), obj.quantity, obj.unit_price); 
        
        return new {
            Status = "Save",
            ID = id

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