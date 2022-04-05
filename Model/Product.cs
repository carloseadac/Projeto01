using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Product : IValidateDataObject<Product>
    {
        //Declaração das variáveis
        private String name = "";
        private Double unit_price= 0.0;
        private String bar_code = "";

        //construtor
        public Product()
        {

        }

        //Getters e Setters
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public double getUnitprice()
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

        public bool validateObject(Product obj)
        {
            if(obj.name == null) return false;          
            if(obj.unit_price == 0.0) return false;            
            if(obj.bar_code == null) return false;
            return true;
        }
    }
}
