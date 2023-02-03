using System;
using System.Collections.Generic;
using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class ManagerManager : IManagerManager
    {
        public static List<Manager> managerDatabase = new List<Manager>();
        IUserManager userManager = new UserManager();
        IWalletManager walletManager = new WalletManager();
      
        public Manager DeleteManager(int userId)
        {
            foreach (var manager in managerDatabase)
            {
                var user = userManager.GetUser(userId);
                if(manager.UserId == userId)
                {
                    managerDatabase.Remove(manager);
                }
            }
            return null;
        }

        public Manager Get(string email)
        {
            var user = userManager.GetUserByEmail(email);
            foreach (var manager in managerDatabase)
            {
                if(user.Id == manager.UserId)
                {
                    return manager;
                }
            }
            return null;
        }

        public void GetAllManager()
        {
           foreach (var manager in managerDatabase)
           {
                if(manager.Role == "Manager")
                {
                    var user = userManager.GetUser(manager.UserId);
                    Console.WriteLine($"{user.Id}\t{user.Name}\t{user.Email}\t{user.PhoneNuber}");
       
                }
            }
        }

        public Manager GetManager(int id)
        {
            foreach (var manager in managerDatabase)
            {
                if(manager.Id == id)
                {
                    return manager;
                }
            }
            return null;
        }

        public Manager GetManagerUserId(int userId)
        {
            foreach (var manager in managerDatabase)
            {
                if(manager.UserId == userId)
                {
                    return manager;
                }
            }
            return null;
        }

       

        public void RegisterManager()
        {
           var manager = new Manager(managerDatabase.Count + 1, UserManager.userDatabase.Count, GenerateManagerRegistrationNumber(), "Manager");
            managerDatabase.Add(manager);
            var user = userManager.GetUser(manager.UserId);
            var createWallet = walletManager.CreateWallet(user.Id,user.Email);
            

            Console.WriteLine($"Congrats mr/mrs {user.Name},your account Number is {createWallet.AccountNumber} your reg no is {manager.StaffRegNo}");
        }

          private string GenerateManagerRegistrationNumber()
        {
            return "CLH/CTM/00" + (managerDatabase.Count + 1).ToString();
        }
    }
}