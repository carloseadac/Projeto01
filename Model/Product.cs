using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        //Declaração das variáveis
        private String name = "";
        private Double unit_price;
        private String bar_code = "";

        //Getters e Setters
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public double getUnitPrice()
        {
            return unit_price;
        }
        public void setUnitPrice(double unit_price)
        {
            this.unit_price = unit_price;
        }
        public string getBarCode()
        {
            return bar_code;
        }
        public void setBarCode(string bar_code)
        {
            this.bar_code = bar_code;
        }

    }
}
