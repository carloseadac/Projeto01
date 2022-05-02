using Enums;
namespace DAO;

public class Purchase
{
    public int id;
    public Store store;
    public Client client;
    public Product product;
    public DateTime date_purchase;
    public String number_confirmation;
    public String number_nf;
    public PaymentEnum payment_type;
    public PurchaseStatusEnum purchase_status;
}