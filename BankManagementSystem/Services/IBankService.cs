using BankManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    internal interface IBankService
    {
        Bank[] Banks { get; }   
        void UserRegistration(string bankname,string name, string surname, string email, string password, bool Isadmin);
        bool UserLogin(string bankname,string email, string password);
        void FindUserByEmail(string bankname,string email);
        void CheckBalance(string bankname,string email);
        void TopUpBalance(string bankname,string email, double IncreaseAmount);
        string ChangePassword(string bankname,string email,string oldpassword, string NewPassword);

        void BankUserList(string bankname);
        void BlockUser(string bankname,string email,string blockemail);
      
    }
}
