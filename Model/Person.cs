using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;

namespace Model
{
    public class Person
    {
        //declarando variáveis
        protected String name;
        protected DateTime date_of_birth;
        protected String document;
        protected String email;
        protected String phone;
        protected String login;
        protected String passwd;
        protected Address address;

        //construtor
        protected Person(Address address) { this.address = address; }

        public Person(){}

        //getters e setters
        public DateTime getDate_of_birth()
        {
            return date_of_birth;
        }
        public void SetDate_of_birth(DateTime date_of_birth)
        {
            this.date_of_birth = date_of_birth;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
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
        public string getPasswd()
        {
            return passwd;
        }
        public void setPasswd(string passwd)
        {
            this.passwd = passwd;
        }


        
    }
}
