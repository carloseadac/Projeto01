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

        public static Client getInstance()
        {
            if(instance == null)
            {
                instance = new Client();
            }
            return instance;
        }
    }
}
