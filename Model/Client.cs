using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Client : Person, IValidateDataObject<Client>
    {
        private static Client instance;

        //construtor
        private Client(Address address) : base(address) { this.address = address; }

 
        public static Client getInstance(Address address)
        {
            if(instance == null)
            {
                instance = new Client(address);
            }
            return instance;
        }

        public bool validateObject(Client obj)
        {
            if(obj.date_of_birth > DateTime.Now || DateTime.Compare(obj.date_of_birth,new DateTime(1900,1,1)) < 0)
            {
                return false;
            }
            else if(obj.email == null)
            {
                return false;
            }
            else if(obj.document == null)
            {
                return false;
            }
            else if(obj.name == null)
            {
                return false;
            }
            else if (obj.phone == null)
            {
                return false;
            }
            else if (obj.login == null)
            {
                return false;
            }
            return true;
        }
    }
}
