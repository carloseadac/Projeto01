using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Owner : Person, IValidateDataObject<Owner>
    {
        private static Owner instance;
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
        public bool validateObject(Owner obj)
        {
            if(obj.date_of_birth > DateTime.Now || DateTime.Compare(obj.date_of_birth,new DateTime(1900,1,1)) < 0) return false;
            if(obj.email == null) return false;
            if(obj.document == null) return false;
            if(obj.name == null) return false;            
            if(obj.phone == null) return false;             
            if(obj.login == null) return false;      
            return true;
        }
    }
}
