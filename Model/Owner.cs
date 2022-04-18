using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;


namespace Model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        private static Owner instance;
        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
        Guid uuid = Guid.NewGuid();
        //construtor
        private Owner(Address address) : base(address){this.address = address;}

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
            return true;
        }
        public Owner convertDTOToModel(OwnerDTO obj)
        {
            var owner = new Owner(Address.convertDTOToModel(obj.address));
            owner.setDocument(obj.document);
            owner.setName(obj.name);
            owner.SetDate_of_birth(obj.date_of_birth);
            owner.setEmail(obj.email);
            owner.setPhone(obj.phone);
            owner.setLogin(obj.login);
            
            return owner;
        }
        public void delete(OwnerDTO obj){
        }
        public int save()
        {
            var id = 0;
            using(var context = new DaoContext())
            {
                var owner = new DAO.Owner{
                    name = this.name,
                    date_of_birth = this.date_of_birth,
                    document = this.document,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    address = this.address
                };

            context.Owner.Add(owner);
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
            ownerDTO.address = this.address;
        }
    }
}
