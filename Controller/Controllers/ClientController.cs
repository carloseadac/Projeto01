using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public Object registerClient([FromBody] ClientDTO clientDTO){
        var client = Client.convertDTOToModel(clientDTO);
        var id = client.save();
        return new{
            name = clientDTO.name,
            date_of_birth = clientDTO.date_of_birth,
            document = clientDTO.document,
            email = clientDTO.email,
            phone = clientDTO.phone,
            login = clientDTO.login,
            passwd = clientDTO.passwd,
            adress = clientDTO.address,
            id = id
        };  
    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document){
        var client = Model.Client.find(document);
        return client;
    }
}
