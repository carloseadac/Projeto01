using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

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

        private PaymentEnum payment_type;
        private PurchaseStatusEnum purchase_status;

        private List<Product> products = new List<Product>();
        public List<PurchaseDTO> purchaseDTO = new List<PurchaseDTO>();

        public Purchase(){}
        public Purchase(Store store, Client client){
            this.store = store;
            this.client = client;
        }
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

        public void setPurchaseStatus(PurchaseStatusEnum purchase_status)
        {
            this.purchase_status = purchase_status;
        }
        public PurchaseStatusEnum getPurchaseStatus()
        {
            return purchase_status;
        }
        public void setPaymentType(PaymentEnum payment_type){
            this.payment_type = payment_type;
        }
        public PaymentEnum getPaymentType(){
            return payment_type;
        }
        
        public bool validateObject()//Purchase obj)
        {
             if(this.getDataPurchase() == null)
            {
                return false;
            }
            else if(this.getNumberConfirmation() == null)
            {
                return false;
            }
            else if(this.getNumberNf() == null)
            {
                return false;
            }
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
        public void delete(PurchaseDTO obj){

        }

        public int save(int client, int store, int product, DateTime data, PaymentEnum tipo, PurchaseStatusEnum status, string confirmado, string nf)
        {
            var id = 0;
            using (var context = new DaoContext())
            {
                var clientDAO =  context.clients.FirstOrDefault(c => c.id == client);
                var storeDAO = context.stores.FirstOrDefault(s =>s.id ==store);
                var productsDAO = context.products.FirstOrDefault(x=> x.id == product);
                
                var purchase = new DAO.Purchase {
                    date_purchase = data,
                    payment_type = tipo,
                    purchase_status = status,
                    // number_confirmation = this.number_confirmation,
                    // number_nf = this.number_nf,
                    number_confirmation = confirmado,
                    number_nf = nf,
                    client = clientDAO,
                    store = storeDAO,
                    product = productsDAO
                };
                
                context.purchases.Add(purchase);
                // context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                // context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                // context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = purchase.id;
            }
         return id;
        }

        public void update(PurchaseDTO obj){

        }

        public void updateStatus(PurchaseStatusEnum PurchaseStatusEnum){
            this.purchase_status = PurchaseStatusEnum;
        }

        public PurchaseDTO findById(int id){
            return new PurchaseDTO();
        }

        public List<PurchaseDTO> getAll(){
            return this.purchaseDTO;
        }

        public PurchaseDTO convertModelToDTO(){
            var purchaseDTO = new PurchaseDTO();
            purchaseDTO.date_purchase = this.date_purchase;
            purchaseDTO.number_confirmation = this.number_confirmation;
            purchaseDTO.number_nf = this.number_nf;
            purchaseDTO.payment_type = this.payment_type;
            purchaseDTO.purchase_status = this.purchase_status;
            foreach(var prod in this.products){
                purchaseDTO.products.Add(prod.convertModelToDTO());
            }
            return purchaseDTO;
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj){

            var storeModel = Model.Store.findStore(obj.store.CNPJ);
            var products = new List<Model.Product>();

            Purchase purchase = new Purchase();
            purchase.setClient(Client.convertDTOToModel(obj.client));
            purchase.setStore(Store.convertDTOToModel(obj.store));
            purchase.setDataPurchase(obj.date_purchase);
            purchase.setNumberConfirmation(obj.number_confirmation);
            purchase.setNumberNf(obj.number_nf);
            purchase.setPaymentType(obj.payment_type);
            purchase.setPurchaseStatus(obj.purchase_status);

            foreach(ProductDTO prod in obj.products){ 
                products.Add(Product.convertDTOToModel(prod));
            }
            purchase.setProducts(products);
            return purchase;
        }

        public void addNewProduct(Product prod){
            products.Add(prod);
        }

        public static List<object> getStorePurchases(string CNPJ){
        using(var context = new DaoContext()){
            var storePurchase = context.purchases
            .Include(s => s.store)
            .Include(o => o.store.owner)
            .Include(a => a.store.owner.address)
            .Include(p => p.product)
            .Include(c => c.client)
            .Include(a => a.client.address)
            .Where(p => p.store.CNPJ == CNPJ);
             List<object> compras = new List<object>();
             foreach(var compra in storePurchase){
                 compras.Add(compra);
                }
                return compras;
            }
        }

        public static List<object> getClientPurchases(int clientID){
            using(var context = new DaoContext()){
                var clientPurchase = context.purchases
                .Include(s => s.store)
                .Include(p => p.product)
                .Where(p => p.client.id == clientID);

                List<object> purchases = new List<object>();
                foreach(object purchase in clientPurchase){
                    purchases.Add(purchase);
                }
                return purchases;

            }
        }


    }
}
