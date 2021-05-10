using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question5
    {
        public void PassCheck()
        {
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter the username");
                string UName = Console.ReadLine();
                Console.WriteLine("Please enter the password");
                string Password = Console.ReadLine();
               
                if (UName == "Admin" && Password == "admin")
                {
                    Console.WriteLine("Welcome");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username and password");
                    if (i == 2)
                    {
                        Console.WriteLine("Sorry you have already tried 3 times");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again!!");
                    }
                    
                }
               

            }
        }
           
        //static void Main(string[] args)
        //{
        //    Question5 quest = new Question5();
        //    quest.PassCheck();
        //}
    }
}
