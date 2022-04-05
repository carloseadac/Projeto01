using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Store : IValidateDataObject<Store>
    {
        //declarando variáveis
        private String name = "";
        private String cnpj = "";
        private Owner owner;
        private List<Purchase> purchases;

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

        public bool validateObject(Store obj)
        {
            if(obj.cnpj == null) return false;
            if(obj.owner == null) return false;
            if(obj.purchases == null) return false;
            if(obj.name == null) return false;
            return true;
        }


    }
}
