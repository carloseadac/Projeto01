namespace DAO;

public class Purchase
{
    public int id;
    public string number_confirmation;
    public string number_nf;
    public int payment_type;
    public string purchase_status;
    public string DateTime data_purchase;
    
    public Product product;
    public Client client;
    public Store store;
}