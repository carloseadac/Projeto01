using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("store")]
public class StoreController : ControllerBase {

    [HttpGet]
    [Route("get/all")]
     public object getAllStore(){ 
        var lojas = model.Store.getStores();
        return lojas;
     }

    [HttpPost]
    [Route("register")]
    public Object regiterStore([FromBody] StoreDTO storeDTO){
        var store = Store.convertDTOToModel(storeDTO);
        var id = store.save(model.Store.getOwnerId(store.getOwner()));
        return new{
            name = storeDTO.name,
            cnpj = storeDTO.CNPJ,
            owner = storeDTO.owner,
            id = id
        };
    }

    [HttpGet]
    [Route("getStore/{CNPJ}")]
    public Object getStoreInformation(string cnpj){
        var store = model.Store.getStoreInfo(cnpj);
        return store;
    }
}