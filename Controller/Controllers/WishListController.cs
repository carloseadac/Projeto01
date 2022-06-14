using Microsoft.AspNetCore.Mvc;
using DTO;
using DAO;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{


    [HttpPost]
    [Route("register")]
    public object addProductToWishList([FromBody]StocksRequestDTO stocksDTO){
        
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var wishlist = new Model.WishList();
        wishlist.save(stocksDTO.id, ClientId);
        return new
        {
                response = "salvou no banco"
        };
    }   

    [Authorize]
    [HttpGet]
    [Route("getwishlist")]
    public IActionResult GetWishList(){
       var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
       var wishilits = Model.WishList.GetWishList(ClientId);

        var result = new ObjectResult(wishilits);

        return result;
    }

    [Authorize]
    [HttpDelete]
    [Route("deletewishlist/{idwishlist}")]
    public string RemoveWishList(int idwishlist){
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var response = Model.WishList.deleteProduct(idwishlist,ClientId);
        return response;
    }


}