using BankSectorApplication.models;

namespace BankSectorApplication.interfaces
{
    public interface ICustomerTransactionManager
    {
         public void CreateTransfer(int userId,decimal amount,string thirdPartyAccount);
         public void CraeteWithdraw(int userId, decimal amount);
         public void GetCustomer(int userId);
    }
}