using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankManagementSystem.Entities
{
    internal class User
    {
        static int Id;
        public double Balance { get; set; }

        private string _name;

        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                if (Check(value))
                {
                    _name = value;
                    Console.WriteLine($"Sertlere uygun olunduguna gore {value} name set edildi");
                }
            }
        }
        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                if (Check(value))
                {
                    _surname = value;
                    Console.WriteLine($"Sertlere uygun olunduguna gore {value} surname set edildi");
                }
            }
        }

        public static  bool Check(string name)
        {
            bool result = true;

            if (name.Length < 3)
            {
                result = false;
                Console.WriteLine($"{name}  uzunlugu 3den kicikdir.");

            }

            return result;


        }
        private string _email;

        public static string[] Emails = new string[0];
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (IsContainsEmail(value))
                {
                    _email = value;
                    Console.WriteLine("Email butun sertlere uygundur deye set edildi");
                }
                else
                {
                    Console.WriteLine($"{value} set edilmedi sebeb:email daxilinde bosluq ola bilmez." +
                        $" Hemcinin 1 @ isaresi olmalidir.1den coxda ola bilmez.Bu sertler odense bele" +
                        $"daxil edilmeyini istenilen email sistemde duplikati olmamalidir");
                }
            }
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex("^[a-z0-9]+(?!.*(?:\\+{2,}|\\-{2,}|\\.{2,}))(?:[\\.+\\-]{0,1}[a-z0-9])*@gmail\\.com$");
            if(!regex.IsMatch(email))
                return false;    
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!email.Contains("@"))
                return false;

            if (email.IndexOf('@') != email.LastIndexOf('@'))
                return false;



           
            return true;
        }

        public static bool IsContainsEmail(string email)
        {

            if (IsValidEmail(email))
            {
                if (Emails.Contains(email.ToLower()))
                    return false;

                Array.Resize(ref Emails, Emails.Length + 1);
                Emails[Emails.Length - 1] = email.ToLower();
                
            }
            return true;

        }
        private string _password;

        public string Password
        {
            get
            {
                return _password;

            }
            set
            {

                if (IsValidPassword(value))
                {
                    _password = value;
                    Console.WriteLine("Passsword uygundur");

                }
                else
                {
                    Console.WriteLine($"{value} minimum 8 uzunluqdadirsa daxilinde minimum 1 kicik ve 1 boyuk herf olmalidir");
                }


            }
        }

        public static bool IsValidPassword(string password)
        {
            bool hasLowerCase = false;
            bool hasUpperCase = false;
            bool result = false;
            if (password.Length >= 8)
            {
                foreach (char letter in password)
                {
                    if (char.IsLower(letter))
                        hasLowerCase = true;          
                    else if (char.IsUpper(letter))
                        hasUpperCase = true;

                }

                
                    result = hasLowerCase && hasUpperCase;
                
                }
            
            else
            {
                Console.WriteLine("Password minimum 8 uzunluqda olmalidir");
            }

            return result;
        }

        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsLogged { get; set; }

        static User()
        {
            Id = 0;
        }
        public User(string name, string surname, string email, string password, bool isadmin =false, bool isBlocked = false, bool isLogged =false)
        {
            Id++;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            IsAdmin = isadmin;
            IsBlocked=isBlocked;
            IsLogged = isLogged;



        }

        public override string ToString()
        {
            return $"User_id:{Id},User_Name:{Name}, User_Surname:{Surname}, User_email:{Email}, User_Status:{(IsAdmin ? "Admin":"User" )}";
        }
    }
}
