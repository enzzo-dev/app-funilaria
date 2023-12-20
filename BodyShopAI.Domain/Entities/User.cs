using BodyShopAI.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Domain.Entities
{
    public class User
    {
        public Guid IdUser {  get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Roles Role { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Phone { get; set; }

        public static void CreateUser(string name, string surname, string email, string password, int phone) 
                                     => new User(name, surname, email, password, phone);

        private User(string name, string surname, string email, string password, int phone)
        {
            IdUser = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
