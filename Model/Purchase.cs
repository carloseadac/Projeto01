using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Interfaces;
using DAO;
using DTO;

namespace Model
{
    public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
    {
        //declarando variaveis
        private DateTime date_purchase;
        private String number_confirmation;
        private String number_nf;
        private Client client;
        private Store store;

        private int payment_type;
        private int purchase_status;
        private double purchase_values = 0;

        private List<Product> product = new List<Product>();



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


        public int getPaymentType() => payment_type;
        public void setPaymentType(PaymentEnum payment_type) { this.payment_type = (int)payment_type; }

        public int getPurchaseStatus() => purchase_status;
        public void setPurchaseStatus(PurchaseStatusEnum purchase_status) { this.purchase_status = (int)purchase_status; }

        public double getPurchaseValues() => purchase_values;
        public void setPurchaseValues(double purchase_values) {this.purchase_values = purchase_values; }

        public bool validateObject()//Purchase obj)
        {
            //if(obj.client == null) return false;
            //if(obj.store == null) return false;
            //if(obj.number_confirmation == null) return false;
            //if(obj.number_nf == null) return false;
            //if(obj.payment_type == 0) return false;
            //if(obj.products == null) return false;
            //if(obj.purchase_status == 0) return false;
            //if(obj.purchase_values == 0) return false;
            //if(obj.date_purchase > DateTime.Now || DateTime.Compare(obj.date_purchase,new DateTime(1900,1,1)) < 0) return false;
            return true;
        }
        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            var purchase = new Purchase();
            purchase.client =  Client.convertDTOToModel(obj.client);
            purchase.store =  Store.convertDTOToModel(obj.store);
            purchase.product=Product.convertDTOToModel(obj.product);
            purchase.setDatePurchase(obj.datePurchase);
            purchase.setPurchaseStatus(obj.purchaseStatus);
            purchase.setPaymentType(obj.paymentType);
            purchase.setNumberConfirmation(obj.numberConfirmation);
            purchase.setNumberNF(obj.numberNF);

            return purchase;
        }


        public void delete(PurchaseDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using(var context = new DAOContext())
            {
                var purchase = new DAO.Purchase{
                    datepurchase = this.datepurchase,
                    purchaseStatus = this.purchaseStatus,
                    paymentType = this.paymentType,
                    numberConfirmation = this.numberConfirmation,
                    numberNF = this.numberNF,
                    product = this.product,
                    store = this.store,
                    client = this.client
                };

                context.Purchase.Add(purchase);

                context.SaveChanges();

                id = purchase.id;

            }
             return id;
        }

        public void update(PurchaseDTO obj)
        {

        }

        public PurchaseDTO findById(int id)
        {

            return new PurchaseDTO();
        }

        public List<PurchaseDTO> getAll()
        {
            return this.PurchaseDTO;
        }


        public PurchaseDTO convertModelToDTO()
        {
            var purchaseDTO = new PurchaseDTO();

            purchaseDTO.datePurchase = this.datePurchase;

            purchaseDTO.purchaseStatus = this.purchaseStatus;

            purchaseDTO.paymentType = this.paymentType;

            purchaseDTO.numberConfirmation = this.numberConfirmation;

            purchaseDTO.numberNF = this.numberNF;

            purchaseDTO.product = this.product.convertModelToDTO();

            purchaseDTO.store = this.store.convertModelToDTO();

            purchaseDTO.client = this.client.convertModelToDTO();

            return purchaseDTO;
        }

    }
}
