using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class CustomerTransactionManager: ICustomerTransactionManager
    {
       
         public static List<CustomerTransaction> customerTransactionsDatabase =  new List<CustomerTransaction>();
        IWalletManager walletManager = new WalletManager();
        public void CraeteWithdraw(int userId, decimal amount)
        {
            var getUserAccount = walletManager.GetWalletByUserId(userId);
            if(getUserAccount.AccountBalance < amount)
            {
                Console.WriteLine("Insufient balance!");
            }
            var customer = new CustomerTransaction(customerTransactionsDatabase.Count+1,userId,amount,DateTime.Now,enums.TransactionType.Withdraw,"");
            customerTransactionsDatabase.Add(customer);
            getUserAccount.AccountBalance -= amount;
            Console.WriteLine($"Debit Alert! {customer.Amount} has been remove from from your account");
       
        }

        public void CreateTransfer(int userId, decimal amount, string thirdPartyAccount)
        {
            var getUserAccount = walletManager.GetWalletByUserId(userId);
            if(getUserAccount.AccountBalance < amount)
            {
                Console.WriteLine("Insufient balance!");
            }
            else
            {
                var getThirdPartyAccountNumber = walletManager.GetWalletAccountNumber(thirdPartyAccount);
                if(getThirdPartyAccountNumber == null)
                {
                    Console.WriteLine("invalid acc number");
                }
                else
                {
                    var customer = new CustomerTransaction(customerTransactionsDatabase.Count+1,userId,amount,DateTime.Now,enums.TransactionType.Transfer,thirdPartyAccount);
                    customerTransactionsDatabase.Add(customer);
                    getThirdPartyAccountNumber.AccountBalance += amount;
                    getUserAccount.AccountBalance -= amount;
                    Console.WriteLine($"Debit Alert!{customer.Amount} has been transferd to {customer.ThirdPartyAccount}");
                }

            }
           
            
        }

        public void GetCustomer(int userId)
        {
           foreach (var customer in customerTransactionsDatabase)
           {
                if(customer.UserId == userId)
                {
                  Console.WriteLine($"{customer.Id}Transactin Date:{customer.Date}Type:{customer.TransactionType}");
                }
           }
        
        }
    }
}