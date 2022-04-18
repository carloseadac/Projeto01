namespace DTO;

public class PurchaseDTO
{
    public string number_confirmation;
    public string number_nf;
    public double purchase_value;
    public int payment_type;
    public int purchase_status;
    public DateTime data_purchase;

    List<ProductDTO> products = new List<ProductDTO>;
}