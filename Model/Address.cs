using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address
    {
        //declarando variáveis
        private String street = "";
        private String city = "";
        private String state = "";
        private String country = "";
        private String poste_code = "";

        //construtor
        public Address()
        {

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
        public string getPosteCode()
        {
            return poste_code;
        }
        public void setPosteCode(string poste_code)
        {
            this.poste_code = poste_code;
        }
        
    }
}
