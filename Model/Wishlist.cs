namespace Model;
using Interfaces;
using DAO;
using Microsoft.EntityFrameworkCore;
using DTO;
public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
{
    private List<Stocks> stocks = new List<Stocks>();
    private Client client;
    public List<WishListDTO> wishListDTO = new List<WishListDTO>();

    public WishList(Client client)
    {
        this.client = client;
    }


    public WishList()
    {
    }

    public static List<WishListResponseDTO> GetWishList(int IdClient){

        using(var context = new DaoContext()){
            var wishLists = context.wishLists.Include(p=>p.client).Include(p=>p.stocks)
            .Include(p=>p.stocks.product).Include(p=> p.stocks.store).Where(i=> i.client.id ==IdClient);
        
            var responseproducts = new List<WishListResponseDTO>();
            foreach(var item in wishLists)
            {
                var newproduct = new WishListResponseDTO();
                newproduct.bar_code = item.stocks.product.bar_code;
                newproduct.IdStocks = item.stocks.id;
                newproduct.idWishlist = item.id;
                newproduct.description = item.stocks.product.description;
                newproduct.image = item.stocks.product.image;
                newproduct.Unit_price = item.stocks.unit_price;
                newproduct.CNPJ = item.stocks.store.CNPJ;
                newproduct.Quantity = item.stocks.quantity;
                newproduct.name = item.stocks.product.name;
                responseproducts.Add(newproduct);
                
            }
            return responseproducts;
        }   
    }
    public static WishList convertDTOToModel(WishListDTO obj)
    {

        var wishList = new WishList(Client.convertDTOToModel(obj.client));

        foreach (var stocks in obj.stocks)
        {
            wishList.addProductToWishList(Stocks.convertDTOToModel(stocks));
        }

        return wishList;
    }

    public void delete()
    {
        
    }

    public static string deleteProduct(int id,int ClientId){
        using (var context = new DaoContext())
        {
            var wishList = context.wishLists
            .FirstOrDefault(w => w.id == id && w.client.id == ClientId);
            context.wishLists.Remove(wishList);
            context.SaveChanges();
            return "sucess";
        }
    }


    public int save(int sctock, int client)
    {
        var id = 0;

        using (var context = new DaoContext())
        {

            var clientDAO = context.clients.FirstOrDefault(c => c.id == client);
            var stocksDAO = context.stocks.FirstOrDefault(x=> x.id == sctock);

            var wishList = new DAO.WishList
            {
                client = clientDAO,
                stocks = stocksDAO
                
            };

            context.wishLists.Add(wishList);
            context.Entry(wishList.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(wishList.stocks).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            context.SaveChanges();

            id = wishList.id;

        }
        return id;
    }

    


    public void update(WishListDTO obj)
    {

    }

    public WishListDTO findById(int id)
    {

        return new WishListDTO();
    }

    public List<WishListDTO> getAll()
    {
        return this.wishListDTO;
    }


    public WishListDTO convertModelToDTO()
    {
        var wishListDTO = new WishListDTO();

        wishListDTO.client = this.client.convertModelToDTO();

        foreach (var stock in this.stocks)
        {
            wishListDTO.stocks.Add(stock.convertModelToDTO());
        }

        return wishListDTO;
    }

    public Boolean validateObject()
    {

        if (this.getClient() == null) return false;
        if (this.GetStocks() == null) return false;
        return true;
    }


    public void setClient(Client client) { this.client = client; }
    public Client getClient() { return this.client; }

    public List<Stocks> GetStocks() { return stocks; }
    public void addProductToWishList(Stocks stock)
    {
        if (!GetStocks().Contains(stock))
        {
            this.stocks.Add(stock);
        }
    }

}