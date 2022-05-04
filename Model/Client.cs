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
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {
        private static Client instance;
        public List<ClientDTO> clientDTO = new List<ClientDTO>();
        Guid guidClient = Guid.NewGuid();

        //construtor
        private Client(Address address) : base(address) { this.address = address; }

        public Client(){}
 
        public static Client getInstance(Address address)
        {
            if(instance == null)
            {
                instance = new Client(address);
            }
            return instance;
        }
        
        public bool validateObject()
        {
            if(this.getDate_of_birth()== null) return false;
            if(this.getEmail() == null) return false;
            if(this.getDocument() == null) return false;
            if(this.getName() == null) return false;            
            if(this.getPhone() == null) return false;             
            if(this.getLogin() == null) return false;    
            if(this.getPasswd() == null) return false;  
            return true;
        }
        
        
        public void delete(ClientDTO obj){
        }
        public int save()
        {
            var id = 0;

            using(var context = new DaoContext())
            {
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

                var client = new DAO.Client();
                client.name = this.name;
                client.date_of_birth = this.date_of_birth;
                client.document = this.document;
                client.email = this.email;
                client.phone = this.phone;
                client.login = this.login;
                client.address = addressDAO;
                client.passwd = this.passwd;

                context.clients.Add(client);
                context.SaveChanges();
                id = client.id;

            }
            return id;
        }
        public void update(ClientDTO obj){

        }

        public ClientDTO findById(int id){
            return new ClientDTO();
        }

        public List<ClientDTO> getAll(){
            return this.clientDTO;
        }

        public ClientDTO convertModelToDTO(){
            var clientDTO = new ClientDTO();
            clientDTO.name = this.name;
            clientDTO.date_of_birth = this.date_of_birth;
            clientDTO.document = this.document;
            clientDTO.email = this.email;
            clientDTO.phone = this.phone;
            clientDTO.login = this.login;
            clientDTO.address = this.address.convertModelToDTO();
            clientDTO.passwd = this.passwd;
            return clientDTO;
        }
        public static Client convertDTOToModel(ClientDTO obj)
        {
            var client = new Client();

            client.setDocument(obj.document);
            client.setName(obj.name);
            client.SetDate_of_birth(obj.date_of_birth);
            client.setEmail(obj.email);
            client.setPhone(obj.phone);
            client.setLogin(obj.login);
            client.setPasswd(obj.passwd);
            client.address = Address.convertDTOToModel(obj.address);
            return client;
        }

        public static object find(String document){
        using (var context = new DaoContext()){
            var client = context.clients.Include(i => i.address).FirstOrDefault(d => d.document == document);
            return new{
                name = client.name,
                date_of_birth = client.date_of_birth,
                document = client.document,
                email = client.email,
                login = client.login,
                passwd = client.passwd,
                phone = client.phone,
                address = client.address
            };
        }
    }
    }
}
