using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Owner : Person
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
    }
}
