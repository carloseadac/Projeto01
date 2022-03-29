using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client : Person
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
    }
}
