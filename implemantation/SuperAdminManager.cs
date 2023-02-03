using System.Collections.Generic;
using BankSectorApplication.enums;
using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class SuperAdminManager : ISuperAdminManager
    {
        public static List<SuperAdmin> superAdminDatabase = new List<SuperAdmin>{
            new SuperAdmin(1, 1, "CLH/STF/001", "SuperAdmin"),
        };
        IUserManager userManager = new UserManager();
        public SuperAdmin Get(string email)
        {
            foreach (var superAdmin in superAdminDatabase)
            {
                var user = userManager.GetUserByEmail(email);
                if(user.Id == superAdmin.UserId)
                {
                    return superAdmin;
                }
            }
            return null;
        }

    }
}