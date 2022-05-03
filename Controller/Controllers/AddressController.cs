using Microsoft.AspNetCore.Mvc;
using System;
using Model;
using DTO;

namespace Controller.Controllers;
[ApiController]
[Route("address")]
public class AddressController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public Object registerAddress([FromBody] AddressDTO address)
    {
        var addressModel = Model.Address.convertDTOToModel(address);

        var id = addressModel.save();
        return new{
            rua = address.street,
            estado = address.state,
            cidade = address.city,
            pais = address.country,
            codigo = address.postal_code,
            id = id
        };

    }
   
}