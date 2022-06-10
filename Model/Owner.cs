using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        private static Owner instance;
        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
        Guid uuid = Guid.NewGuid();
        //construtor
        private Owner(Address address) : base(address){this.address = address;}

        public Owner(){
            
        }

        

        public static Owner getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Owner(address);
                
            }
            return instance;
        }
        public bool validateObject()
        {
            if(this.date_of_birth > DateTime.Now || DateTime.Compare(this.date_of_birth,new DateTime(1900,1,1)) < 0) return false;
            if(this.email == null) return false;
            if(this.document == null) return false;
            if(this.name == null) return false;            
            if(this.phone == null) return false;             
            if(this.login == null) return false;      
            if(this.passwd == null) return false;
            return true;
        }
        public void delete(OwnerDTO obj){

        }

        public int save()
        {
            var id = 0;
        
            using(var context = new DaoContext())
            {
                // var owner = new DAO.Owner{
                //     name = this.name,
                //     date_of_birth = this.date_of_birth,
                //     document = this.document,
                //     email = this.email,
                //     phone = this.phone,
                //     login = this.login,
                //     address = new DAO.Address{
                //         street = this.address.getStreet(),
                //         city =this.address.getCity(),
                //         state = this.address.getState(),
                //         country = this.address.getCountry(),
                //         poste_code = this.address.getPostalCode()
                //     },
                //     password = this.password
                // };

                Console.WriteLine("entrou");
                var addressDAO =  new DAO.Address();
                addressDAO.street = this.address.getStreet();
                Console.WriteLine("entrou street");

                addressDAO.city = this.address.getCity();
                Console.WriteLine("entrou city");

                addressDAO.state = this.address.getState();
                Console.WriteLine("entrou state");

                addressDAO.country = this.address.getCountry();
                Console.WriteLine("entrou country");

                addressDAO.postal_code = this.address.getPostalCode();
                Console.WriteLine("entrou postalcode");

                var owner = new DAO.Owner();
                owner.name = this.name;
                owner.date_of_birth = this.date_of_birth;
                owner.document = this.document;
                owner.email = this.email;
                owner.phone = this.phone;
                owner.login = this.login;
                owner.address = addressDAO;
                owner.passwd = this.passwd;

                context.owners.Add(owner);
                context.SaveChanges();
                id = owner.id;
            }
         return id;
        }

        public void update(OwnerDTO obj){

        }

        public OwnerDTO findById(int id){
            return new OwnerDTO();
        }

        public List<OwnerDTO> getAll(){
            return this.ownerDTO;
        }

        public OwnerDTO convertModelToDTO(){
            var ownerDTO = new OwnerDTO();
            ownerDTO.name = this.name;
            ownerDTO.date_of_birth = this.date_of_birth;
            ownerDTO.document = this.document;
            ownerDTO.email = this.email;
            ownerDTO.phone = this.phone;
            ownerDTO.login = this.login;
            ownerDTO.address = this.address.convertModelToDTO();
            ownerDTO.passwd = this.passwd;

            return ownerDTO;
        }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            
            var owner = new Owner();
            owner.setDocument(obj.document);
            owner.setName(obj.name);
            owner.SetDate_of_birth(obj.date_of_birth);
            owner.setEmail(obj.email);
            owner.setPhone(obj.phone);
            owner.setLogin(obj.login);
            owner.setPasswd(obj.passwd);
            owner.address = Address.convertDTOToModel(obj.address);

            return owner;
        }
        public static (int id, string name, string email)? findLogin(OwnerDTO obj){
            Owner.convertDTOToModel(obj);
            using (var context = new DaoContext()){
                var owner = context.owners.Include(i => i.address).FirstOrDefault(d => d.login == obj.login && d.passwd == obj.passwd);

                if(owner != null){
                    return (owner.id, owner.name, owner.email);
                }
                else return null;
            }
        }

        public static object find(String document){
        using (var context = new DaoContext()){
            var owner = context.owners.Include(i => i.address).FirstOrDefault(d => d.document == document);
            return new{
                name = owner.name,
                date_of_birth = owner.date_of_birth,
                document = owner.document,
                email = owner.email,
                login = owner.login,
                passwd = owner.passwd,
                phone = owner.phone,
                address = owner.address
            };
        }
    }
    public static object findID(int id){
        using (var context = new DaoContext()){
            var owner = context.owners.Include(i => i.address).FirstOrDefault(d => d.id == id);
            return new{
                name = owner.name,
                date_of_birth = owner.date_of_birth,
                document = owner.document,
                email = owner.email,
                login = owner.login,
                passwd = owner.passwd,
                phone = owner.phone,
                address = owner.address
            };
        }
    }
    }
}
