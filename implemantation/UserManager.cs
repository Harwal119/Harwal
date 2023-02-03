using System;
using System.Collections.Generic;
using BankSectorApplication.enums;
using BankSectorApplication.interfaces;
using BankSectorApplication.models;

namespace BankSectorApplication.implemantation
{
    public class UserManager : IUserManager
    {
       
        public static List<User> userDatabase = new List<User>()
        {
           new User(1,"Ade","a@gmail.com", 134, Gender.male, "Abule","08024982606"),
       };


        public User DeleteUser(int id)
        {

            foreach (var user in userDatabase)
            {
                if (user.Id == id)
                {
                    userDatabase.Remove(user);
                }
            }
            return null;
        }



        public void GetAllUser()
        {
            foreach (var user in userDatabase)
            {
                Console.WriteLine($"{user.Name}/t{user.Address}/t{user.Email}/t{user.Gender}/t{user.PhoneNuber}/t{user.Pin}");
            }

        }

        public User GetUser(int id)
        {
            foreach (var user in userDatabase)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public User Login(string email, int pin)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email && user.Pin == pin)
                {
                    return user;
                }
            }
            return null;
        }

        public User RegisterUser(string name, string email, int pin, Gender gender, string address, string phoneNumber)
        {
            var userExist = CheckIfExist(email);
            if (userExist != null)
            {
                Console.WriteLine("User already exist!");
                return null;
            }
            else
            {
                var user = new User(userDatabase.Count + 1, name, email, pin, gender, address, phoneNumber);
                userDatabase.Add(user);
                return user;
            }
        }


        private User CheckIfExist(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }


        public User UpdateUser(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetUserByPin(int pin)
        {
            foreach (var user in userDatabase)
            {
                if (user.Pin == pin)
                {
                    return user;
                }
            }
            return null;
        }
    }
}