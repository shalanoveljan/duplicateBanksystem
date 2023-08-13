using BankManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    internal class BankMenuService
    {
        private readonly static BankService _bankService;

        static BankMenuService()
        {
            _bankService = new BankService();
        }
        public static void UserRegistration()
        {

            Console.WriteLine("Zehmet olmasa BankName daxil edin");

        bankname:
            string bankname = Console.ReadLine();
            if (!User.Check(bankname.Trim()))
            {
                Console.WriteLine("bankname-i yeniden daxil edin ");
                goto bankname;
            }


            Console.WriteLine("Zehmet olmasa Name daxil edin");

            name:
            string name =Console.ReadLine();
            if(!User.Check(name.Trim()))
            {
                Console.WriteLine("name-i yeniden daxil edin ");
                goto name;
            }

            Console.WriteLine("Zehmet olmasa SurName daxil edin");
            surname:
            string surname = Console.ReadLine();
            if (!User.Check(surname) )
            {
                Console.WriteLine("surname-i yeniden daxil edin ");
                goto surname;
            }

            Console.WriteLine("Zehmet olmasa userin Emailini  daxil edin");

            email:
            string email = Console.ReadLine();

            if (!User.IsValidEmail(email))
            {
                Console.WriteLine("email-i yeniden daxil edin ");
                goto email;
            }


            Console.WriteLine("Zehmet olmasa userin passwordunu daxil edin");

            password:
            string password = Console.ReadLine();
            if (!User.IsValidPassword(password))
            {
                Console.WriteLine("password-u yeniden daxil edin ");
                goto password;
            }

            Console.WriteLine("userin admin olub olmadigini qeyd edin");
            admin:
            bool resultAdmin = bool.TryParse(Console.ReadLine(), out bool Resadmin);
            if(!resultAdmin) 
            {
                Console.WriteLine("duzgun sekilde qeyd edin");
                goto admin;
            }

            _bankService.UserRegistration(bankname,name, surname, email, password, Resadmin);



        }

        public static string  UserLogin(out string bankname,out string email)
        {
            Console.WriteLine("Zehmet olmasa BankName daxil edin");

        bankname:
             bankname = Console.ReadLine();
            if (!User.Check(bankname.Trim()))
            {
                Console.WriteLine("bankname-i yeniden daxil edin ");
                goto bankname;
            }

            Console.WriteLine("Zehmet olmasa userin Emailini  daxil edin");

        email:
             email = Console.ReadLine();

            if (!User.IsValidEmail( email))
            {
                Console.WriteLine("email-i yeniden daxil edin ");
                goto email;
            }


            Console.WriteLine("Zehmet olmasa userin passwordunu daxil edin");

        password:
            string password = Console.ReadLine();
            if (!User.IsValidPassword(password))
            {
                Console.WriteLine("password-u yeniden daxil edin ");
                goto password;
            }

            if (_bankService.UserLogin(bankname, email, password))
            {

                return email;
            }

            return "false";



        }

        public static void FindUserByEmail()
        {

            Console.WriteLine("Zehmet olmasa BankName daxil edin");

        bankname:
            string bankname = Console.ReadLine();
            if (!User.Check(bankname.Trim()))
            {
                Console.WriteLine("bankname-i yeniden daxil edin ");
                goto bankname;
            }

            Console.WriteLine("Zehmet olmasa userin Emailini  daxil edin");

        email:
            string email = Console.ReadLine();

            if (!User.IsValidEmail(email)) 
            {
                Console.WriteLine("email-i yeniden daxil edin ");
                goto email;
            }
                _bankService.FindUserByEmail(bankname,email);

        }

        public static void CheckBalance(string bankname, string email) 
        {
          

            _bankService.CheckBalance(bankname,email);

        }
        public static void TopUpBalance(string bankname,string email)
        {
            
        

            Console.WriteLine("elave olunacaq meblegi daxil edin");
        Amount:
            bool resultRow = double.TryParse(Console.ReadLine(), out double inreaseAmount);
            if (!resultRow)
            {
                Console.WriteLine("elave olunacaq meblegi yeniden daxil edin");
                goto Amount;
            }

            _bankService.TopUpBalance(bankname, email, inreaseAmount);


        }

        public static void ChangePassword(string bankname,string email)
        {
            Console.WriteLine("deyismek istediyiniz passwordu daxil edin");
        oldpassword:
            string oldpassword = Console.ReadLine();
            if (!User.IsValidPassword(oldpassword))
            {
                Console.WriteLine("password-u yeniden daxil edin ");
                goto oldpassword;
            }

            Console.WriteLine("Zehmet olmasa userin yeni passwordunu daxil edin");

        newpassword:
            string newpassword = Console.ReadLine();
            if (!User.IsValidPassword(newpassword))
            {
                Console.WriteLine("password-u yeniden daxil edin ");
                goto newpassword;
            }

            Console.WriteLine(_bankService.ChangePassword(bankname, email, oldpassword, newpassword));

        }

        public static void BankUserList(string bankname)
        {

            _bankService.BankUserList(bankname);

        }

        public static void BlockUser(string bankname,string email)
        {

            Console.WriteLine("Zehmet olmasa block edilecek userin Emailini  daxil edin");

        blockemail:
            string blockemail = Console.ReadLine();

            if (User.IsContainsEmail(blockemail))
            {
                Console.WriteLine("block edilecek email-i yeniden daxil edin ");
                goto blockemail;
            }
            _bankService.BlockUser(bankname, email, blockemail);

        }

        public static Bank FindBankByName(string bankname) 
        {
            
            Bank bank=_bankService.FindBankByName(bankname);
            return bank;       
        }


        public static User FindUser(string bankname,string email)
        {
            if (FindBankByName(bankname) != null)
            {
                User user = _bankService.FindUser(FindBankByName(bankname).Name, email);

                return user;
            }
            else
            {
                Console.WriteLine("bu ada uygun bank tapilmadi");
                return null;
            }
        }

        public static void CreateBank()
        {
            Console.WriteLine("Zehmet olmasa BankName daxil edin");

        bankname:
            string bankname = Console.ReadLine();
            if (!User.Check(bankname.Trim()))
            {
                Console.WriteLine("bankname-i yeniden daxil edin ");
                goto bankname;
            }

            _bankService.CreateBank(bankname);
        }
    }
}
