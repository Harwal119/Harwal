namespace BankSectorApplication.models
{
    public class Manager
    {
        public int Id{ get;set; }
        public int UserId{ get;set; }
        public string StaffRegNo{ get;set; }
        public string Role{ get;set; }

        public Manager(int id,int userId,string staffRegNo,string role)
        {
            Id = id;
            UserId = userId;
            StaffRegNo = staffRegNo;
            Role = role;
        }
        

    }
}