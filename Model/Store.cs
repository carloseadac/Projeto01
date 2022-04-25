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
        private String name;
        private String cnpj;
        private Owner owner;
        public List<StoreDTO> StoreDTO = new List<StoreDTO>();
        public List<Purchase> purchases = new List<Purchase>();

        //construtor
        public Store(Owner owner)
        {
            this.owner = owner;
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
        public void addNewPurchase(Purchase purchase)
        {
            purchases.Add(purchase);
        }

        public bool validateObject()//Store obj)
        {
            //if(obj.cnpj == null) return false;
            //if(obj.owner == null) return false;
            //if(obj.purchases == null) return false;
            //if(obj.name == null) return false;
            return true;
        }

        public static Store convertDTOToModel(StoreDTO obj)
        {
            var store = new Store(Owner.convertDTOToModel(obj.owner));
            store.setName(obj.name);
            store.setCNPJ(obj.CNPJ);        
            foreach(var item in obj.purchase){
                store.purchase.Add(Purchase.convertDTOToModel(item));
            }
            
            return  store;
        }
        public void delete(StoreDTO obj)
        {

        }
        public int save()
        {
            var id = 0;

            using(var context = new DAOContext())
            {
                var ownerDAO = context.owner.Where(c => c.id == owner).Single();
                var store = new DAO.Store{
                    name = this.name,
                    CNPJ = this.CNPJ,
                    owner = ownerDAO
                };

                context.Store.Add(store);

                context.SaveChanges();

                id = store.id;

            }
             return id;
        }

        public void update(StoreDTO obj)
        {

        }

        public StoreDTO findById(int id)
        {

            return new StoreDTO();
        }

        public List<StoreDTO> getAll()
        {        
            return this.storeDTO;      
        }

    
        public StoreDTO convertModelToDTO()
        {
            var storeDTO = new StoreDTO();

            StoreDTO.name = this.name;

            StoreDTO.CNPJ = this.CNPJ;

            StoreDTO.owner = this.owner.convertModelToDTO();

            foreach(var item in this.purchases){
                storeDTO.purchase.Add(item.convertModelToDTO());
            }

            return storeDTO;
        }


    }
}
