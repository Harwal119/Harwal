using BankSectorApplication.models;

namespace BankSectorApplication.interfaces
{
    public interface IManagerManager
    {
         public void RegisterManager();
        public Manager GetManager(int id);
        public Manager GetManagerUserId(int userId);
        public Manager Get(string email);
        public void GetAllManager(); 
        public Manager DeleteManager(int userId); 
    }
}