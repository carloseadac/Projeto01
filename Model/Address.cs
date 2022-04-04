using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Address : IValidateDataObject<Address>
    {
        //declarando variáveis
        private String street = "";
        private String city = "";
        private String state = "";
        private String country = "";
        private String poste_code = "";

        //construtor
        public Address(string street, string city, string state, string country, string poste_code)
        {
            this.street = street;  
            this.city = city;
            this.state = state;
            this.country = country;
            this.poste_code = poste_code;

        }

        //getters e setters
        public string getStreet()
        {
            return street;
        }
        public void setStreet(string street)
        {
            this.street = street;
        }
        public string getCity()
        {
            return city;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public string getState()
        {
            return state;
        }
        public void setState(string state)
        {
            this.state = state;
        }
        public string getCountry()
        {
            return country;
        }
        public void setCountry(string country)
        {
            this.country = country;
        }
        public string getPostalCode()
        {
            return poste_code;
        }
        public void setPostalCode(string poste_code)
        {
            this.poste_code = poste_code;
        }
        //interfaces
        public bool validateObject(Address obj)
        {
            if(obj.street == null)
            {
                return false;
            }
            else if(obj.city == null)
            {
                return false;
            }
            else if (obj.state == null)
            {
                return false;
            }
            else if (obj.poste_code == null)
            {
                return false;
            }
            else if (obj.country == null)
            {
                return false;
            }
            return true;
        }
    }
}
