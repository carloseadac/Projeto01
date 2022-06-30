using Microsoft.AspNetCore.Mvc;
using DTO;
using DAO;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
namespace Controller.Controllers;

[ApiController]
[Route("store")]
public class StoreController : ControllerBase {

    [HttpGet]
    [Route("get/all")]
     public object getAllStore(){ 
        var lojas = Model.Store.getStores();
        return lojas;
     }

    [HttpPost]
    [Route("register")]
    public IActionResult registerStore([FromBody] StoreDTO storeDTO){
        var OwnerId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var store = Model.Store.convertDTOToModel(storeDTO);
        var id = store.save(OwnerId);
        Console.WriteLine(id);
        return new ObjectResult( new{
            name = storeDTO.name,
            cnpj = storeDTO.CNPJ,
            owner = storeDTO.OwnerDTO,
            id = id
        });

    }

    [HttpGet]
    [Route("getStore/{CNPJ}")]
    public Object getStoreInformation(string cnpj){
        var store = Model.Store.getStoreInfo(cnpj);
        return store;
    }
    [HttpGet]
    [Route("getID/{id}")]
    public Object getStorebyIDOwner(int id){
        var store = Model.Store.getStorebyIDOwner(id);
        Console.WriteLine(id);
        return store;
    }
}