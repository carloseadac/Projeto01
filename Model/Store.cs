using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DTO;
using DAO;

namespace Model
{
    public class Store : IValidateDataObject
    {
        //declarando variáveis
        Owner owner;
        private String name;
        private String cnpj;
        List<StoreDTO> StoreDTO = new List<StoreDTO>();
        public List<Purchase> purchases = new List<Purchase>();
        public void addNewPurchase(Purchase purchase){
        purchases.Add(purchase);
        }

        //construtor
        public Store(Owner owner)
        {
            this.owner = owner;
        }

        public Store(){

        }

        //getters e setters
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getCNPJ()
        {
            return cnpj;
        }
        public void setCNPJ(string cnpj)
        {
            this.cnpj = cnpj;
        }
        public Owner getOwner()
        {
            return owner;
        }
        public void setOwner(Owner owner)
        {
            this.owner = owner;
        }
        public List<Purchase> getPurchases()
        {
            return purchases;
        }


        public bool validateObject(Store obj)
        {
            if(this.getCNPJ() == null) return false;
            if(this.getName() == null) return false;
            return true;
        }

        public void delete(StoreDTO obj){

        }

        public int save(int owner)
        {
            var id = 0;

            using(var context = new DaoContext())
            {
                var ownerDAO = context.owners.Where(c => c.id == owner).Single();
                var store = new DAO.Store{
                    owner = ownerDAO,
                    name = this.name,
                    CNPJ = this.cnpj
                    //lista de purchase
                };

                context.stores.Add(store);
                context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = store.id;
            }
            return id;
        }

        public void update(StoreDTO obj){

        }

        public StoreDTO findById(int id){
            return new StoreDTO();
        }

        public List<StoreDTO> getAll(){
            return this.StoreDTO;
        }

        public StoreDTO convertModelToDTO(){
            var storeDTO = new StoreDTO();
            storeDTO.name = this.name;
            storeDTO.CNPJ = this.cnpj;
            storeDTO.OwnerDTO = this.owner.convertModelToDTO();
            foreach(var purchase in this.purchases){
                storeDTO.purchases.Add(purchase.convertModelToDTO());
            }

            return storeDTO;
        }

        public static Store convertDTOToModel(StoreDTO obj){
            var store = new Store();

            if(obj.OwnerDTO != null){
                store.owner = Owner.convertDTOToModel(obj.OwnerDTO);
            }

            store.setCNPJ(obj.CNPJ);
            store.setName(obj.name);
            foreach(var purchase in obj.purchases){
                store.addNewPurchase(Purchase.convertDTOToModel(purchase));
            }

            return store;
        }

        public static object getStoreInfo(string cnpj){
            using(var context = new DaoContext()){
                var storeDAO = context.stores.Include(s => s.owner).Include(s => s.owner.address).FirstOrDefault(p => p.CNPJ == cnpj);

                return new {
                    name = storeDAO.name,
                    cnpj = storeDAO.CNPJ,
                    owner = storeDAO.owner,
                };
            }
        }  
        public static List<object> getStores(){
            using (var context = new DaoContext()){
                var stores = context.stores.Include(s => s.owner).Include(a => a.owner.address);
                List<object> lojas = new List<object>();
                foreach(var store in stores){
                    lojas.Add(store);
                }
                return lojas;
            }
            
        }
        public static int getOwnerId(Owner owner){
            int id;
            using(var context = new DaoContext()){
                var ownerDAO = context.owners.FirstOrDefault(i => i.document == owner.getDocument());
                id = ownerDAO.id;
            }
            return id;
        }
        public static int findId(string CNPJ){
            using(var context = new DaoContext()){
                var store = context.stores.FirstOrDefault(s => s.CNPJ == CNPJ);
                return store.id;
            }
        }

        public bool validateObject()
        {
            if(this.getCNPJ() == null)
            {
                return false;
            }
            if(this.getName() == null)
            {
                return false;
            }
            return true;
        }
        public static object getStorebyIDOwner(int idOwner){
        using(var context = new DaoContext()){
            var storeDAO = context.stores.Include(s => s.owner).Include(s => s.owner.address).FirstOrDefault(p => p.owner.id == idOwner);
            Console.WriteLine(storeDAO.CNPJ);
            return new {
                name = storeDAO.name,
                cnpj = storeDAO.CNPJ,
            };
        }
    }
    }
}
