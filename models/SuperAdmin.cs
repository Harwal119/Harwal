namespace BankSectorApplication.models
{
    public class SuperAdmin
    {
        public int Id{ get;set; }
        public int UserId{ get;set; }
        public string StaffRegNo{ get;set; }
        public string Role{ get;set; }

        public SuperAdmin(int id,int userId,string staffRegNo,string role)
        {
            Id = id;
            UserId = userId;
            StaffRegNo = staffRegNo;
            Role = role;
        }
    }
}