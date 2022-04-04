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
            if (obj.date_of_birth == null)
            {
                return false;
            }
            else if (obj.email == null)
            {
                return false;
            }
            else if (obj.document == null)
            {
                return false;
            }
            else if (obj.name == null)
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
