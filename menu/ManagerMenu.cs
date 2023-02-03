using System;
using BankSectorApplication.implemantation;
using BankSectorApplication.interfaces;

namespace BankSectorApplication.menu
{
    public class ManagerMenu
    {
      
     
        public void RealManagerMenu()
        {
            
            ICustomerManager customerManager = new CustomerManager();
            Console.Write("enter 1 to view allCustomer\nenter two to delete customer");
            int option = int.Parse(Console.ReadLine());


            if(option == 1)
            {
                customerManager.GetAllCustomer();
                RealManagerMenu();
            }
            else if(option == 2)
            {
                customerManager.GetAllCustomer();
                Console.WriteLine("Enter user id");
                int id = int.Parse(Console.ReadLine());
                customerManager.DeleteCustomer(id);
                RealManagerMenu();
            }

        }
       
    }
}