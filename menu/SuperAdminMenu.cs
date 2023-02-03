using System;
using BankSectorApplication.enums;
using BankSectorApplication.implemantation;
using BankSectorApplication.interfaces;

namespace BankSectorApplication.menu
{
    public class SuperAdminMenu
    {
        public void RealSuperAdminMenu()
        {
            ICustomerManager customerManager = new CustomerManager();
            IManagerManager managerManager = new ManagerManager();
            IUserManager userManager = new UserManager();
            IWalletManager walletManager = new WalletManager();
            Console.WriteLine("enter 1 to view all customers \n enter 2 to create manager\n enter 3 to view all Managers\n enter 4 to DeleteManager\n enter 5 to Pay ManagerSalary\n enter 0 to go log out");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                customerManager.GetAllCustomer();
                RealSuperAdminMenu();
            }
            else if (option == 2)
            {
                Console.WriteLine("Register Manager");
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your pin: ");
                int pin = int.Parse(Console.ReadLine());
                Console.Write("Enter 1 for male,2 for female: ");
                int gender = int.Parse(Console.ReadLine());
                Console.Write("Enter your address: ");
                string address = Console.ReadLine();
                Console.Write("Enter your phone number: ");
                string phoneNumber = Console.ReadLine();
                userManager.RegisterUser(name,email,pin,(Gender)gender,address,phoneNumber);
                managerManager.RegisterManager();
                RealSuperAdminMenu();
            }
            else if (option == 3)
            {
                managerManager.GetAllManager();
                RealSuperAdminMenu();
            }
            else if (option == 4)
            {
                managerManager.GetAllManager();
                Console.Write("Enter Manager Id: ");
                int id = int.Parse(Console.ReadLine());
                managerManager.DeleteManager(id);
                RealSuperAdminMenu();
            }
            else if(option == 5)
            {
                managerManager.GetAllManager();
                Console.Write("Enter Manager Account Number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter manager salary: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                walletManager.FundWallet(amount,accountNumber);
                RealSuperAdminMenu();
            }
            else if(option == 0)
            {
                MainMenu mainMenu = new MainMenu();
                Console.WriteLine("user successfully logout");
                mainMenu.RealMenu();
            }
            else
            {
                System.Console.WriteLine("wrong input");
                RealSuperAdminMenu();
            }
        }
    }
}