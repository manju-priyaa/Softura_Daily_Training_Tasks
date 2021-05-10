using System;
using System.Collections.Generic;
using System.Text;

namespace SofturaTest3Project
{
    class Question6
    {
        public void CowBull()
        {
            string[] wordsArr = new string[5];
            wordsArr[0] = "kite";
            wordsArr[1] = "four";
            wordsArr[2] = "neat";
            wordsArr[3] = "play";
            wordsArr[4] = "goal";
            for (int i = 0; i < wordsArr.Length; i++)
            {
                Console.WriteLine("Enter the guess");
                string guess = Console.ReadLine();
                string arr = wordsArr[i];
                int cow = 0, bulls = 0;
                if (arr.Length == guess.Length)
                {

                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == guess[i])
                        {
                            cow++;
                        }
                        else
                        {
                            for (int j = 0; j < arr.Length; j++)
                            {
                                if (arr[i] == guess[j] && i != j)
                                {
                                    bulls++;
                                }
                            }
                        }
                    }

                    if (cow == arr.Length)
                    {
                        Console.WriteLine("Cows-" + cow + " Bulls-" + bulls);
                        Console.WriteLine("You Win!!");
                        Console.WriteLine("Do You want to play again. 1(Yes)/0(No):");
                        int option = Convert.ToInt32(Console.ReadLine());
                        while (option >0)
                        {
                            CowBull(); 
                        }
                    }
                    Console.WriteLine("Cows-" + cow + " Bulls-" + bulls);
                    CowBull();
                }
                else
                {
                    Console.WriteLine("Must enter " + arr.Length + " letter a Word");
                }

            }
        }
        static void Main(string[] args)
        {
            Question6 quest = new Question6();
            Console.WriteLine("Play..");
            quest.CowBull();
        }
    }
}
