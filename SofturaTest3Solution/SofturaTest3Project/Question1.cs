using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question1
    {
        public void NumDivBy7Sum()
        {
            int number;
            List<int> numList = new List<int>();
            Console.WriteLine("Enter the numbers: ");
            for (int i = 0; i < 10; i++)
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number % 7 == 0)
                    numList.Add(number); 

            }
            Console.WriteLine("The numbers divisible by 7 are: ");
            for (int i = 0; i <numList.Count; i++)
            {
                Console.WriteLine(numList[i]);
            }

        }

        //static void Main(string[] args)
        //{
        //    Question1 quest = new Question1();
        //    quest.NumDivBy7Sum();
        //}
    }
}
