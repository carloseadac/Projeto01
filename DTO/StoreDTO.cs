namespace DTO;

public class StoreDTO
{
    public String Name;
    public String CNPJ;

    public OwnerDTO OwnerDTO;
    List<PurchaseDTO> purchases = new List<PurchaseDTO>();
}