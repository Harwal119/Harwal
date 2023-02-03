using System;
using System.Collections.Generic;
using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class CustomerManager : ICustomerManager
    {
        IUserManager userManager = new UserManager();
        IWalletManager walletManager = new WalletManager();
        public static List<Customer> customerDatabase = new List<Customer>();
        
    
        public Customer DeleteCustomer(int userId)
        {
            foreach (var customer in customerDatabase)
            {
               if(customer.UserId == userId)
               {
                    customerDatabase.Remove(customer);
               }
                
            }
                return null;
        }

        
        public void GetAllCustomer()
        {
            foreach (var customer in customerDatabase)
            {
                var user = userManager.GetUser(customer.UserId);
                Console.WriteLine($"{user.Name}/t{user.Email}/t{user.PhoneNuber}");
            }
        }

        public Customer GetCustomer(int id)
        {
            
            foreach (var customer in customerDatabase)
            {
                if ( customer.Id == id )
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer GetCustomerByUserId(int userId)
        {
            foreach (var customer in customerDatabase)
            {
                if ( customer.UserId == userId )
                {
                    return customer;
                }
            }
            return null;
        }
  
      

        public void RegisterCustomer()
        {
             var customer = new Customer(customerDatabase.Count + 1, UserManager.userDatabase.Count, "Customer");
            customerDatabase.Add(customer);

            var user = userManager.GetUser(customer.UserId);
            var createWallet = walletManager.CreateWallet(user.Id,user.Pin.ToString());
            Console.WriteLine($"Congrats {user.Name}, your account Number is {createWallet.AccountNumber} and your wallet balance is {createWallet.AccountBalance}.");
        }

        public Customer UpdateCustomerByEmail(string email)
        {
            foreach (var customer in customerDatabase)
            {
                var user = userManager.GetUserByEmail(email);
                if( user.Email == email )
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Get(string email)
        {

            var user = userManager.GetUserByEmail(email);
            foreach (var customer in customerDatabase)
            {
                if(user.Id == customer.UserId)
                {
                    
                    return customer;
                }
            }
            return null;
        }

        public void GetCustomerByEmail(string email)
        {
            var user = userManager.GetUserByEmail(email);
            foreach (var customer in customerDatabase)
            {
                if(user.Id == customer.UserId)
                {
                    var getwallet = walletManager.GetWalletByUserId(user.Id);
                    Console.WriteLine($" Id : {customer.Id}\t Name : {user.Name}\t Email: {user.Email}\t AccountNumber : {getwallet.AccountNumber}\tAccount Balance : {getwallet.AccountBalance} ");
                }
            }
            
        }

       
    }
}