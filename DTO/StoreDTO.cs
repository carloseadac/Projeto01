namespace DTO;

public class StoreDTO
{
    public String Name;
    public String CNPJ;

    public OwnerDTO OwnerDTO;
    public List<PurchaseDTO> purchases = new List<PurchaseDTO>();
}