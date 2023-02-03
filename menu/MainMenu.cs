using System;
using BankSectorApplication.enums;
using BankSectorApplication.implemantation;
using BankSectorApplication.interfaces;

namespace BankSectorApplication.menu
{
    public class MainMenu
    {
        IUserManager userManager = new UserManager();
        ICustomerManager customerManager = new CustomerManager();
        IManagerManager managerManager = new ManagerManager();
        ISuperAdminManager superAdminManager = new SuperAdminManager();
        SuperAdminMenu superAdminMenu = new SuperAdminMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public void RealMenu()
        {
            Console.WriteLine("Welcome to Bank App \n Enter 1 to SignUp\n Enter 2 to Login");
            int option = int.Parse(Console.ReadLine());

            if(option == 1)
            {
                SignUpMenu();
            }
            else if(option == 2)
            {
                LoginMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                RealMenu();
            }

        }

        
        public void SignUpMenu()
        {
             Console.WriteLine("**SINGN UP**");
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
             customerManager.RegisterCustomer();
            RealMenu();

             
        }

        public void LoginMenu()
        {
            Console.WriteLine("**LOG IN**");
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter pin: ");
            int pin = int.Parse(Console.ReadLine());
            var login = userManager.Login(email,pin);
            if(login == null)
            {
                Console.WriteLine("wrong cridentials");
                RealMenu();
            }
            else
            {
                Console.WriteLine("login successful");

                var superAdmin = superAdminManager.Get(login.Email);
                var customer = customerManager.Get(login.Email);
                var manager = managerManager.Get(login.Email);
                if(superAdmin != null)
                {
                    superAdminMenu.RealSuperAdminMenu();
                }
                else if(customer != null)
                {
                    customerMenu.RealCustomerMenu();
                }
                else if (manager != null)
                {
                    managerMenu.RealManagerMenu();
                }
                
            }
            
        }
    }
}