using System;
using TransportBLLibrary;

namespace TransportFEApplication
{
    class Program
    {
        EmployeeLogin login;
        EmployeeManagement managment;
        EmployeeBL bl;
        public Program()
        {
            bl = new EmployeeBL();
            login = new EmployeeLogin(bl);
            managment = new EmployeeManagement(bl);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("*******");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Print All");
                Console.WriteLine("4. Sort and Print All");
                Console.WriteLine("5. Update Password");
                Console.WriteLine("6. Exit");
                Console.WriteLine("..........................");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        login.RegisterEmployee();
                        break;
                    case 2:
                        login.UserLogin();
                        break;
                    case 3:
                        managment.PrintAllEmployee();
                        break;
                    case 4:
                        managment.PrintEmployeesSortById();
                        break;
                    case 5:
                        managment.ResetPassword();
                        break;
                    case 6:
                        Console.WriteLine("Exiting.....");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("##########################");

            } while (choice!=6);

        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            new Program().PrintMenu();
        }
    }
}
