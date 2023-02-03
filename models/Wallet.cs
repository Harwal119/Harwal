namespace BankSectorApplication.models
{
    public class Wallet
    {
        public int Id{ get;set; }
        public int UserId{get;set;}
        public string WalletPassword{get;set;}
        public decimal AccountBalance{ get;set;}
        public string AccountNumber{ get;set; }

      public Wallet(int id,int userId, decimal accountBalance,string accountNumber,string walletPassword)
      {
        Id = id;
        UserId = userId;
        AccountBalance = accountBalance;
        AccountNumber = accountNumber;
        WalletPassword = walletPassword;
      }
    }
}