using System;
using Interfaces;
using DAO;
using DTO;
using System.Collections.Generic;



namespace Model
{
    public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
    {
        //declarando variáveis
        private String street;
        private String city;
        private String state;
        private String country;
        private String postal_code;
        public List<AddressDTO> addressDTO = new List<AddressDTO>();


        //construtor
        public Address(string street, string city, string state, string country, string postal_code)
        {
            this.street = street;  
            this.city = city;
            this.state = state;
            this.country = country;
            this.postal_code = postal_code;

        }
        public static Address convertDTOToModel(AddressDTO obj)
        {
            return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
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
            return postal_code;
        }
        public void setPostalCode(string postal_code)
        {
            this.postal_code = postal_code;
        }
        //interfaces
        public bool validateObject()
        {
            if(this.street == null) return false;            
            if(this.city == null) return false;           
            if(this.state == null) return false;                      
            if(this.postal_code == null) return false;           
            if(this.country == null) return false;           
            return true;
        }
        
        public void delete(AddressDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using(var context = new DaoContext())
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

        public static AddressDTO ConvertDAOToDTO(DAO.Address addressDAO){
            var addressDTO = new AddressDTO();
            addressDTO.postal_code = addressDAO.postal_code;
            addressDTO.id = addressDAO.id;
            addressDTO.street = addressDAO.street;
            addressDTO.state = addressDAO.state;
            addressDTO.city = addressDAO.city;
            addressDTO.country = addressDAO.country;
            return addressDTO;
        }

    }
}
