using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question2
    {
        public void PrimeNumber()
        {
            List<int> primeList = new List<int>();
            Console.WriteLine("Enter the minimum value:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the maximum value: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int flag;
            for (int i = number1; i <= number2; i++)
            {
                if (i == 1)
                {
                    continue;
                }
                flag = 1;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                
                if (flag == 1)
                {
                    primeList.Add(i); 
                }
            }
            if (number1 < number2)
            {
                Console.WriteLine("The prime numbers between " + number1 + " and " + number2 + " are : ");
                for (int i = 0; i < primeList.Count; i++)
                {
                    Console.WriteLine(primeList[i]);
                }

            }
            else
                Console.WriteLine("Invalid Entry .");

        }

        //static void Main(string[] args)
        //{
        //    Question2 quest = new Question2();
        //    quest.PrimeNumber();
        //}
    }
}
