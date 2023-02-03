namespace BankSectorApplication.models
{
    public class Customer
    {
        public int Id{ get;set; }
        public int UserId{ get;set; }
        public string Role{ get;set; }
      


        public Customer(int id, int userId,string role)
        {
            Id = id;
            UserId = userId;
            Role = role;
        }
        
    }
}