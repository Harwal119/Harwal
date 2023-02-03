using BankSectorApplication.enums;
using BankSectorApplication.models;

namespace BankSectorApplication.interfaces
{
    public interface IUserManager
    {
         public User RegisterUser(string name, string email, int pin, Gender gender, string address, string phoneNumber);
        public User Login(string email, int pin);
        public User GetUser(int id);
         public User GetUserByPin(int Pin);
        public User GetUserByEmail(string email); 
        public void GetAllUser(); 
        public User DeleteUser(int id); 
        public User UpdateUser(string email); 


    }
}