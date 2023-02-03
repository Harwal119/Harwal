using System;
using System.Collections.Generic;
using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class WalletManager : IWalletManager
    {
        public static List<Wallet> walletDatabase = new List<Wallet>();
        public Wallet CreateWallet(int userId,string walletPassword)
        {

            var wallet = new Wallet(walletDatabase.Count+1,userId,0,GenerateAccountNumber(),walletPassword);
            walletDatabase.Add(wallet);
            return wallet;
        }
         
        

        public void FundWallet(decimal amount,string accountNumber)
        {
            foreach (var item in walletDatabase)
            {
                if(item.AccountNumber == accountNumber)
                {
                    item.AccountBalance+=amount;
                    Console.WriteLine($"your balance is now {item.AccountBalance}");
                }
            }
            
        }

        public Wallet GetWalletAccountNumber(string accountNumber)
        {
            foreach (var item in walletDatabase)
            {
                if(item.AccountNumber == accountNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public void GetWalletByCustomerAccountNumberAndPin(string accountNumber,string pin)
        {
             foreach (var item in walletDatabase)
            {
                if(item.AccountNumber == accountNumber && item.WalletPassword == pin)
                {
                    Console.WriteLine($"your wallet balance is {item.AccountBalance}");
                }
            }
        }

        public Wallet GetWalletByUserId(int UserId)
        {
            foreach (var item in walletDatabase)
            {
                if(item.UserId == UserId)
                {
                    return item;
                }
            }
            return null;
        }
        private string GenerateAccountNumber()
        {
             Random rand = new Random();
            return rand.Next(100000000,999999999).ToString();
        }
    }
}