namespace DTO;

public class StoreDTO
{
    public String name;
    public String CNPJ;

    public OwnerDTO OwnerDTO;
    public List<PurchaseDTO> purchases = new List<PurchaseDTO>();
}