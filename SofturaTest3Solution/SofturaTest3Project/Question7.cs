using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SofturaTest3Project
{
    class Question7
    {
        public void CreditCardCheck()
        {
            int number, sum = 0, rev1 = 0,count=0;
            Console.WriteLine("Enter the card Number: ");
            var cardNumber = Console.ReadLine();
            var reverse = Reverse(cardNumber);
            var numbers = reverse.Split(" ");

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        //even position multiply by 2
                        sum = numbers[i][j] * 2;
                        if (sum > 10)
                        {
                            number = sum;
                            sum = 0;
                            while (number != 0)
                            {
                                rev1 = number % 10;
                                sum = sum + rev1;
                                number = number / 10;
                            }
                        }
                        count = count + sum;
                    }
                    else
                        count = count + numbers[i][j];
                }
            }
            // to check if the number if divsible by 10
            if (count % 10 == 0)
                Console.WriteLine("Card is Valid");
            else
                Console.WriteLine("Invalid card!!");
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        //static void Main(string[] args)
        //{
        //    Question7 quest = new Question7();
        //    quest.CreditCardCheck();
        //}
    }
}





