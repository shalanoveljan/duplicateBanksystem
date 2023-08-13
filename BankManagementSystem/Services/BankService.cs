using BankManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    internal class BankService : IBankService
    {
      //  Bank _bank = new Bank(1);

         Bank[] _banks;
        public Bank[] Banks => _banks;

        public BankService()
        {
           // _bank.users = new User[0];
            _banks = new Bank[0];
            
           
        }

        public void CreateBank(string bankname)
        {

            Bank bank = new Bank(bankname);
            if (FindBankByName(bankname) == null)
            {
                Array.Resize(ref _banks, _banks.Length + 1);
                _banks[_banks.Length - 1] = bank;
                Console.WriteLine("Bank Yaradildi");
            }
            else
            {
                Console.WriteLine("Bu adli bank yaradilib, yeniden yaradila bilmez");
            }
        }
        public  Bank FindBankByName(string bankname)
        {
           
            foreach (Bank bank in _banks)
            {
                if (bank != null && bank.Name == bankname)
                {
                   
                    return bank;
                }
            }
            return null;
        }


        public void UserRegistration(string bankname, string name, string surname, string email, string password, bool isAdmin)
        {
            Bank _bank=FindBankByName(bankname);
            if (_bank != null)
            {
                User user = new User(name, surname, email, password, isAdmin);
                
                    if (FindUser(bankname, user.Email.ToLower()) == null)
                    {

                        Array.Resize(ref _bank.users, _bank.users.Length + 1);
                        _bank.users[_bank.users.Length - 1] = user;
                        Console.WriteLine($"{user.Name} ugurla qeydiyyatdan kecdi");
                    }
                    else
                    {
                        Console.WriteLine($"{user.Email} emaile malik user artiq sistemde movcuddur");
                    }
              
            }
            else
            {
                Console.WriteLine("Bank tapilmadi");
            }
        }
        public User FindUser(string bankname,string email)
        {
            Bank _bank = new Bank(bankname);

            User existedUser = null;
            string changedemail = email.ToLower();

            foreach (User user in _bank.users)
            {
                string Currentemail = user.Email.ToLower();
                if (Currentemail == changedemail)
                {
                    existedUser = user;
                }
            }
            return existedUser;
        }
        public bool UserLogin(string bankname,string email, string password)
        {
            Bank _bank = FindBankByName(bankname);
            foreach (User user in _bank.users)
            {
                if (user.Email.ToLower() == email.ToLower() && user.Password == password && user.IsBlocked == false)
                {
                    user.IsLogged = true;

                    Console.WriteLine($"{email} malik user terefinden hesaba giris edildi");
                    return true;
                }

            }
            Console.WriteLine("userin emaili ve ya passwordu duzgun veya bir-birine uygun deyil veya user admin terefinden block edilib");

            return false;

        }



        public void FindUserByEmail(string bankname,string email)
        {
           
            User user = FindUser(bankname,email);
            if (user is null)
            {
                Console.WriteLine($"{email} user cannot be found in bank system");
                return;
            }
            Console.WriteLine(user);

        }

        public void CheckBalance(string bankname,string email)
        {
            User user = FindUser(bankname,email.ToLower());

            Console.WriteLine($"{email}-e sahib userin balansi:{user.Balance}");


        }

        public void TopUpBalance(string bankname,string email, double IncreaseAmount)
        {
            User user = FindUser(bankname,email.ToLower());


            Console.WriteLine($"Balans {IncreaseAmount} qeder artirildi");
            user.Balance = user.Balance + IncreaseAmount;

            Console.WriteLine($"{email}-e sahib userin cari balansi:{user.Balance}");


        }

        public string ChangePassword(string bankname,string email, string oldpassword, string NewPassword)
        {
            User user = FindUser(bankname,email.ToLower());
            if (user.Password != oldpassword)
            {

                return "password is false";
            }




            user.Password = NewPassword;
            return "Password has been successfuly changed";



        }
        public void BankUserList(string bankname)
        {
            Bank _bank = FindBankByName(bankname);
            foreach (User user1 in _bank.users)
            {
                Console.WriteLine($"Name:{user1.Name}-->Surname:{user1.Surname}");

            }
        }

        public void BlockUser(string bankname,string email, string blockemail)
        {
            User user = FindUser(bankname, email.ToLower());
            User user1 = FindUser(bankname,blockemail.ToLower());



            if (user1.IsAdmin == false)
            {
                if (user1.IsBlocked == false)
                {

                    user1.IsBlocked = true;
                    Console.WriteLine($"{user1.Name} adli user  {user.Name} adli admin terefinden block edildi");
                }
                else
                {
                    Console.WriteLine("bu user onsuzda admin terefinden block edilib");
                }

            }
            else
            {

                Console.WriteLine("BlockUser is Admin");
            }
        }



    }


}

