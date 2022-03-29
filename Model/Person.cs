using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        //declarando variáveis
        protected String name = "";
        protected String age = "";
        protected String document = "";
        protected String email = "";
        protected String phone = "";
        protected String login = "";
        protected Address address;

        //getters e setters
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getAge()
        {
            return age;
        }
        public void setAge(string age)
        {
            this.age = age;
        }
        public string getDocument()
        {
            return document;
        }
        public void setDocument(string document)
        {
            this.document = document;
        }
        public string getEmail()
        {
            return email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getPhone()
        {
            return phone;
        }
        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getLogin()
        {
            return login;
        }
        public void setLogin(string login)
        {
            this.login = login;
        }
        public Address getAddress()
        {
            return address;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }


    }
}
