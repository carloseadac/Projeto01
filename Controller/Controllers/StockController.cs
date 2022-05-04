using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("stock")]

public class StockController : ControllerBase{
    [HttpPost]
    public void addProductToStock(Object request){

    }

    [HttpPut]
    public void updateStock(Object request){

    }
}