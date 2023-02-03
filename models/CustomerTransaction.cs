using BankSectorApplication.enums;

namespace BankSectorApplication.models
{
    public class CustomerTransaction
    {
        public int Id{ get;set;}
        public int UserId{ get;set;}
        public decimal Amount{ get;set;}
        public DateTime Date{ get;set;}
        public TransactionType TransactionType{ get;set;}
        public string ThirdPartyAccount{ get;set;}

        public CustomerTransaction(int id,int userId,decimal amount,DateTime date,TransactionType transactionType,string thirdPartyAccountn)
        {
            Id = id;
            UserId = userId;
            Amount = amount;
            Date = date;
            TransactionType = transactionType;
            ThirdPartyAccount = thirdPartyAccountn;
        }
    }
}