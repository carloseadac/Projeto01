namespace DTO;
using Enums;
public class PurchaseDTO
{
    public DateTime date_purchase;

    public double purchase_value;

    public PaymentEnum payment_type;

    public PurchaseStatusEnum purchase_status;

    public String number_confirmation;

    public String number_nf;

    public List<ProductDTO> products = new List<ProductDTO>();

    public StoreDTO store;

    public ClientDTO client;
}