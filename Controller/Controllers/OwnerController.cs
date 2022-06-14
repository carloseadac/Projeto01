namespace Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using DTO;
using Model;

[ApiController]
[Route("owner")]
public class OwnerController : ControllerBase
{
    public IConfiguration _configuration;

    public OwnerController(IConfiguration config){
        _configuration = config;
    }


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
    [HttpPost]
    [Route("api")]

    public IActionResult tokenGenerate([FromBody] OwnerDTO login){
        if(login != null && login.login != null && login.passwd != null){
            var user = Model.Owner.findLogin(login);
            Response.Headers.Add("Access-Control-Allow-Origin" , "*");
            if(user != null){
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Value.id.ToString()),
                    new Claim("UserName", user.Value.name),
                    new Claim("Email", user.Value.email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["JwtAudience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                var clientResponse = new{
                    id = user.Value.id,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    name =  user.Value.name
                };
                return Ok(clientResponse);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest("Empty credentials");
        }
    }

}