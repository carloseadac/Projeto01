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
            if(obj.street == null) return false;            
            if(obj.city == null) return false;           
            if(obj.state == null) return false;                      
            if(obj.poste_code == null) return false;           
            if(obj.country == null) return false;           
            return true;
        }

        public void delete(AddressDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using(var context = new DAOContext())
            {
                var address = new DAO.Address{
                    street = this.street,
                    city = this.city,
                    state = this.state,
                    country = this.country,
                    postal_code = this.postal_code
                };

                context.Address.Add(address);

                context.SaveChanges();

                id = address.id;

            }
             return id;
        }

        public void update(AddressDTO obj)
        {

        }

        public AddressDTO findById(int id)
        {

            return new AddressDTO();
        }

        public List<AddressDTO> getAll()
        {        
            return this.addressDTO;      
        }

   
        public AddressDTO convertModelToDTO()
        {
            var addressDTO = new AddressDTO();

            addressDTO.street = this.street;

            addressDTO.state = this.state;

            addressDTO.city = this.city;

            addressDTO.country = this.country;

            addressDTO.postal_code = this.postal_code;

            return addressDTO;
        }

    }
}
