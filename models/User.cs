using BankSectorApplication.enums;

namespace BankSectorApplication.models
{
    public class User
    {
      public int Id{ get;set; }
     public string Name{ get;set;}
      public string Email{ get;set; }
      public int Pin{ get;set; }
      public Gender Gender{ get;set; }
      public string Address{ get;set; } 
      public string PhoneNuber{ get;set; }


      public User(int id, string name, string email, int pin, Gender gender, string address, string phoneNumber )
      {
        Id = id;
        Name = name;
        Gender = gender;
        Email = email;
        Pin = pin;
        Address = address;
        PhoneNuber = phoneNumber;
      }

    }
}