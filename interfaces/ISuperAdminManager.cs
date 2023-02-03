using BankSectorApplication.enums;
using BankSectorApplication.models;

namespace BankSectorApplication.interfaces
{
    public interface ISuperAdminManager
    {
        public SuperAdmin Get(string email);
    }
}