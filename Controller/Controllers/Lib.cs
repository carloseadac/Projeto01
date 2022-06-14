using System.IdentityModel.Tokens.Jwt;

namespace Controller;

public class Lib
{
    public static int GetIdFromRequest(string TokenFromHead)
    {

        var SlicedToken = TokenFromHead.Substring(7, TokenFromHead.Length - 7);
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(SlicedToken);

        return  int.Parse(jsonToken.Claims.First(claim => claim.Type == "UserId").Value);
    }

}