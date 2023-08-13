using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Entities
{
    internal class Bank
    {
        static int Id { get; set; }
       public  User[] users;
        public string Name;

        static  Bank()
        {
            Id = 0;
        }


        public Bank(string name)
        {
             Id++;
            Name = name;
            users = new User[0];

          
        }
    }
}
