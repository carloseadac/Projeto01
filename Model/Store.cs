using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public bool validateObject()//Store obj)
        {
            //if(obj.cnpj == null) return false;
            //if(obj.owner == null) return false;
            //if(obj.purchases == null) return false;
            //if(obj.name == null) return false;
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


    }
}
