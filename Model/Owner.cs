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

        public static Owner getInstance()
        {
            if (instance == null)
            {
                instance = new Owner();
                
            }
            return instance;
        }
    }
}
