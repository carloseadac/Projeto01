using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Model
{
    public class Purchase
    {
        //declarando variaveis
        private DateTime date_purchase;
        private String number_confirmation = "";
        private String number_nf = "";
        private Client client;
        private Store store;

        private int payment;
        private int purchase_status;
        private double purchase_values = 0;

        private List<Product> products;



        //getters e setters
        public DateTime getDataPurchase()
        {
            return date_purchase;
        }
        public void setDataPurchase(DateTime date_purchase)
        {
            this.date_purchase = date_purchase;
        }
       
        public string getNumberConfirmation()
        {
            return number_confirmation;
        }
        public void setNumberConfirmation(string number_confirmation)
        {
            this.number_confirmation = number_confirmation;
        }
        public string getNumberNf()
        {
            return number_nf;
        }
        public void setNumberNf(string number_nf)
        {
            this.number_nf = number_nf;
        }
        public Client getClient()
        {
            return client;
        }
        public void setClient(Client client)
        {
            this.client = client;
        }
        public Store getStore()
        {
            return store;
        }
        public void setStore(Store store)
        {
            this.store = store;
        }

        public List<Product> getProducts()
        {
            return this.products;
        }
        public void setProducts(List<Product> products)
        {
            this.products = products;
        }
        

        public int getPaymentType() => payment;
        public void setPaymentType(PaymentEnum payment) { this.payment = (int)payment; }

        public int getPurchaseStatus() => purchase_status;
        public void setPurchaseStatus(PurchaseStatusEnum purchase_status) { this.purchase_status = (int)purchase_status; }

        public double getPurchaseValues() => purchase_values;
        public void setPurchaseValues(double purchase_values) {this.purchase_values = purchase_values; }

    }
}
