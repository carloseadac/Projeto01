using System;
namespace DTO;
public class WishListDTO
{
    public ClientDTO client;
    public List<StocksDTO> stocks = new List<StocksDTO>();
}
