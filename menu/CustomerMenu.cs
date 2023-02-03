using System;
using BankSectorApplication.implemantation;
using BankSectorApplication.interfaces;

namespace BankSectorApplication.menu
{
    public class CustomerMenu
    {
       public void RealCustomerMenu()
       {
            ICustomerManager customerManager = new CustomerManager();
            IWalletManager walletManager = new WalletManager();
            IUserManager userManager = new UserManager();
            MainMenu mainMenu = new MainMenu();
            ICustomerTransactionManager customerTransactionManager = new CustomerTransactionManager();
    
            Console.WriteLine(" enter 1 to view Profile\n enter 2 to fund your wallet\n enter 3 to view balance\n enter 4 to transfer\n enter 5 to withdraw\n enter 6 to viewTransaction\n enter 7 to logout");
            int input = int.Parse(Console.ReadLine());
            if(input == 1)
            {
                Console.WriteLine("Your Email is needed to access your profile!! Kindly provide your email ");
                string email = Console.ReadLine();
                customerManager.GetCustomerByEmail(email);
                RealCustomerMenu();
            }
            else if(input == 2)
            {
                Console.WriteLine("Kindly provide your Account Number and amount to fund your wallet");
                Console.Write("Enter your account Number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter the amount you want to add to your wallet: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                walletManager.FundWallet(amount, accountNumber);

                RealCustomerMenu();
            }
            else if (input == 3)
            {
                Console.WriteLine("Kindly provide your Wallet Password to view your wallet balance");
                Console.Write("Enter your Account Number: ");
                string accNo = Console.ReadLine();
                Console.Write("Enter your walletPassword: ");
                string pin = Console.ReadLine();
                walletManager.GetWalletByCustomerAccountNumberAndPin(accNo,pin);
                RealCustomerMenu();
            }
            else if(input == 4)
            {
                Console.Write("Enter your Thirdparty Account Number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter the amount to transfer: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter your bank pin: ");
                int pin = int.Parse(Console.ReadLine());
                var getPin = userManager.GetUserByPin(pin);
                if(getPin == null)
                {
                    Console.WriteLine("incorrect pin");
                    RealCustomerMenu();
                }
                else
                {
                    customerTransactionManager.CreateTransfer(getPin.Id,amount,accountNumber);
                    RealCustomerMenu();
                }

            }
            else if(input == 5)
            {
                Console.Write("Enter the amount you want to withdraw: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter your bank pin: ");
                int pin = int.Parse(Console.ReadLine());
                var getPin = userManager.GetUserByPin(pin);
                if(getPin == null)
                {
                    Console.WriteLine("incorrect pin");
                    RealCustomerMenu();
                }
                else
                {
                    
                    customerTransactionManager.CraeteWithdraw(getPin.Id,amount);
                    RealCustomerMenu();
                }
                mainMenu.RealMenu();
            }
            else if(input == 6)
            {
                Console.WriteLine("Enter your pin");
                int pin = int.Parse(Console.ReadLine());
                var user = userManager.GetUserByPin(pin);
                customerTransactionManager.GetCustomer(user.Id);
                RealCustomerMenu();
            }
            else if(input == 7)
            {
                mainMenu.RealMenu();
            }
            else
            {
                System.Console.WriteLine("invalid input");
                RealCustomerMenu();
            }
           
            
            
            
       }
    }
}