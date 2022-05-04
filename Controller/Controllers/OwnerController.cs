using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("owner")]
public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public Object registerOwner(OwnerDTO ownerDTO){
        var owner = Owner.convertDTOToModel(ownerDTO);
        var id = owner.save();
        return new{
            name = ownerDTO.name,
            date_of_birth = ownerDTO.date_of_birth,
            document = ownerDTO.document,
            email = ownerDTO.email,
            phone = ownerDTO.phone,
            login = ownerDTO.login,
            passwd = ownerDTO.passwd,
            adress = ownerDTO.address,
            id = id
        };  
    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document){
        var owner = Model.Owner.find(document);
        return owner;
    }
}