using BankManagementSystem.Entities;
using BankManagementSystem.Enums;
using BankManagementSystem.Services;

//BankService Bs=new BankService();
//Bs.UserRegistration("Elcan", "Salanov", "Elcan@GMAIL.com", "el23WDd453",true);
//BankService Bs1=new BankService();
//Bs1.UserRegistration("Elena", "Salanfd", "Elcan@GMAIL.com", "el23WDd453",false);
//BankService Bs2=new BankService();
//Bs2.UserRegistration("Elcanon", "Samanov", "Elcan@GMAIL.com", "el23W23",false);

 static void BankMenyu()
{
    for (int i = 0; i <= (int)BankMenu.Exit; i++)
    {
        Console.WriteLine($"{i}.{((BankMenu)i).ToString()}");
    }
}

static void AdminLoginMenu()
{
    for (int i = 0; i <= (int)Login.BlockUser; i++)
    {
        Console.WriteLine($"{i}.{((Login)i).ToString()}");
    }
}

static void LoginMenu()
{
    for (int i = 0; i <= (int)Login.ChangePassword; i++)
    {
        Console.WriteLine($"{i}.{((Login)i).ToString()}");
    }
}

int answer;
int selection;

do
{

  BankMenyu();
 bool result=int.TryParse(Console.ReadLine(), out answer);
    if (result)
    {
        switch (answer)
        {
            case (int)BankMenu.CreateBank:
                BankMenuService.CreateBank();
                break; 

            case (int)BankMenu.UserRegistration:
                BankMenuService.UserRegistration();
                break;

            case (int)BankMenu.UserLogin:
               // string email = string.Empty;
               // string bankname = string.Empty;
                string response = BankMenuService.UserLogin(out string email, out string bankname);
               
                if (response == "false")
                {
                    break;
                }
                else
                {

                   // string email = response;

                    bool IsAdmin = BankMenuService.FindUser(bankname,email).IsAdmin;
                    if (!IsAdmin)
                    {

                        do
                        {

                            LoginMenu();
                            bool res = int.TryParse(Console.ReadLine(), out selection);
                            if (selection != 0)
                            {
                                if (res)
                                {
                                    switch (selection)
                                    {
                                        case (int)Login.CheckBalance:
                                            BankMenuService.CheckBalance(bankname,email);
                                            break;
                                        case (int)Login.TopUpBalance:
                                            BankMenuService.TopUpBalance(bankname,email);
                                            break;
                                        case (int)Login.ChangePassword:
                                            BankMenuService.ChangePassword(bankname, email);
                                            break;


                                        default:
                                            Console.WriteLine("Yalniz 1-3 arasi reqem daxil edilmelidi"); break;


                                    }
                                }

                                else
                                {
                                    Console.WriteLine("yalniz integer eded daxil edilmelidi");
                                }
                            }
                        } while (selection != (int)Login.LogOut);
                    }
                    else
                    {

                        do
                        {

                            AdminLoginMenu();
                            bool res = int.TryParse(Console.ReadLine(), out selection);

                            if (selection != 0)
                            {
                                if (res)
                                {
                                    switch (selection)
                                    {
                                        case (int)Login.CheckBalance:
                                            BankMenuService.CheckBalance(bankname, email);
                                            break;
                                        case (int)Login.TopUpBalance:
                                            BankMenuService.TopUpBalance(bankname, email);
                                            break;
                                        case (int)Login.ChangePassword:
                                            BankMenuService.ChangePassword(bankname, email);
                                            break;
                                        case (int)Login.BankUserList:
                                            BankMenuService.BankUserList(bankname);
                                            break;
                                        case (int)Login.BlockUser:
                                            BankMenuService.BlockUser(bankname, email);
                                            break;

                                        default:
                                            Console.WriteLine("Yalniz 1-5 arasi reqem daxil edilmelidi"); break;


                                    }
                                }

                                else
                                {
                                    Console.WriteLine("yalniz integer eded daxil edilmelidi");
                                }
                            }
                        } while (selection != (int)Login.LogOut);
                    }


                    break;
                }
            case (int)BankMenu.FindUserByEmail:
                BankMenuService.FindUserByEmail();
                break;
            
        }
    }
    else
    {
        Console.WriteLine("yalniz integer eded daxil edilmelidi");
    }

}while(answer!=(int)BankMenu.Exit);