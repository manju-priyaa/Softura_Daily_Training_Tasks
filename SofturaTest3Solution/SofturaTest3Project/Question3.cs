using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question3
    {
        public void repeatingNumbers()
        {
            int number;
            List<int> repList = new List<int>();
            Console.WriteLine("Please enter the numbers. (-ve number will end the loop)");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                repList.Add(number);
            } while (number >= 0);

            Console.WriteLine("The repeating numbers are: ");
            for (int i = 0; i < repList.Count; i++)
            {
                for (int j = i + 1; j < repList.Count; j++)
                {
                    if (repList[i] == repList[j])
                        Console.WriteLine(repList[j]);
                }
            }

        }
        //static void Main(string[] args)
        //{
        //    Question3 quest = new Question3();
        //    quest.repeatingNumbers();
        //}
    }
}
