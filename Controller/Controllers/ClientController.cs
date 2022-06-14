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
[Route("client")]
public class ClientController : ControllerBase
{

    public IConfiguration _configuration;

    public ClientController(IConfiguration config){
        _configuration = config;
    }

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

    [HttpPost]
    [Route("get/login")]
    public IActionResult getInformations([FromBody] ClientDTO obj){
        Console.WriteLine("cheguei aqui");
        var client = Model.Client.findLogin(obj);
        var result = new ObjectResult(client);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }

    [HttpPost]
    [Route("api")]
    public IActionResult tokenGenerate([FromBody] ClientDTO login){
        if(login != null && login.login != null && login.passwd != null){
            var user = Model.Client.findLogin(login);
            Console.WriteLine(user);
            if(user.Value.id != 0){
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Value.id.ToString()),
                    new Claim("UserName", user.Value.name),
                    new Claim("Email", user.Value.email),
                    new Claim("Email", user.Value.email),
                    new Claim("Email", user.Value.email),
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
