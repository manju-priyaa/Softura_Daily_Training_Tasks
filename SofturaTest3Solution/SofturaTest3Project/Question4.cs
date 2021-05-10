using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question4
    {
        public void AsceNumbers()
        {
            int number;
            List<int> repList = new List<int>();
            Console.WriteLine("Please enter the numbers. (0 will end the loop)");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                repList.Add(number);
                
            } while (number != 0);

            Console.WriteLine("The numbers after sorting : ");
            repList.Sort();
            for (int i = 1; i < repList.Count; i++)
            {
                Console.WriteLine(repList[i]);
            }
            

        }
        //static void Main(string[] args)
        //{
        //    Question4 quest = new Question4();
        //    quest.AsceNumbers();
        //}
    }
}
