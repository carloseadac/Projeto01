using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Purchase
    {
        //declarando variaveis
        private DateTime date_purchase;
        private String payment = "";
        private String number_confirmation = "";
        private String number_nf = "";
        private Client client;

        //getters e setters
        public DateTime getDatePurchase()
        {
            return date_purchase;
        }
        public void setDatePurchase(DateTime date_purchase)
        {
            this.date_purchase = date_purchase;
        }
        public string getPayment()
        {
            return payment;
        }
        public void setPayment(string payment)
        {
            this.payment = payment;
        }
        public string getNumberConfirmation()
        {
            return number_confirmation;
        }
        public void setNumberConfirmation(string number_confirmation)
        {
            this.number_confirmation = number_confirmation;
        }
        public string getNumberNF()
        {
            return number_nf;
        }
        public void setNumberNF(string number_nf)
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
    }
}
