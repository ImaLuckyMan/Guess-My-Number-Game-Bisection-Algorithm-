using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Guess_My_Number_Game__Bisection_Algorithm
{
    /* The bisection algorithm is nice because it is guaranteed to find an answer (or return if there is no answer) in logarithmic 
     * time of the size of the list. Only 10 repetitions of the function are necessary to find a result in a list of 1024 items, and 
     * only 20 repetitions to find a result in a list of 1,000,000 items. Mathematically, the time complexity of the bisection algorithm 
     * is LaTeX: \log_2\left(n\right)log 2( n ), where LaTeX: nn is the length of the sorted list to be searched. */

    class GuessMyNumber
    {
        static void Main()
        {
            /* An input is given by the user and the computer automatically figures out what was guessed through trial and error. */
            Console.WriteLine("Please input a number between 1 and 10");
            int input = (Convert.ToInt32(Console.ReadLine()));
            BisectionAlgorithm(input);

            /* Another method for completing the first task */
            //Console.WriteLine("Please input a number between 1 and 10");
            //int input2 = (Convert.ToInt32(Console.ReadLine()));
            //BisectionAlgorithm2(input2);

            /* The computer randomly chooses a number between 1 and 1000 and then the human guesses the number */
            
            Random rdm = new Random();
            int num = rdm.Next(1, 1001);
            Console.WriteLine("\n\t Can you guess my number? It's between 1 and 1000.");
            HumanPlays(num);

            /* The human chooses a number between 1 and 100 and then the computer guesses the number */
            int start = 1;
            int end = 100;
            int guess = (end + start) / 2;
            ComputerPlays(guess, start, end);

        }

        /* Write a console application implementing the bisection algorithm. As the initial list, use an integer array from 1 to 10, 
        * like this: int[] list = 1,2,3,4,5,6,7,8,9,10;. As input, have the user select a number from 1 to 10. Have the application 
        * print each step. Use appropriate exception handling to guard against invalid input from the user.*/
        static void BisectionAlgorithm(int guess)
        {
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (guess == 5)
            { Console.WriteLine("You Guessed 5"); }

            if (guess < 5)
            {
                if (guess < 3)
                {
                    if (guess == 1)
                    { Console.WriteLine("You guessed 1"); }
                    else { Console.WriteLine("You guessed 2"); }
                }

                if (guess > 3)
                {
                    if (guess == 4)
                    { Console.WriteLine("You guessed 4"); }
                }
                else Console.WriteLine("You guessed 3");
            }

            if (guess > 5)
            {
                if (guess < 8)
                {
                    if (guess == 6)
                        Console.WriteLine("You guessed 6");
                    else Console.WriteLine("You guessed 7");
                }

                if (guess >= 8)
                {
                    if (guess < 9)
                    { Console.WriteLine("You guessed 8"); }
                    if (guess > 9)
                    { Console.WriteLine("You guessed 10"); }
                    else Console.WriteLine("You guessed 9");
                }

            }

        }

        /* Another method may be to recreate the array each time */

        //static void BisectionAlgorithm2(int guess)
        //{
        //    int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //
        //    if (guess == 5) { Console.WriteLine("You guessed 5"); }
        //    if (guess < 5)
        //    {
        //        int[] list { start() to end() };
        //    }
        //
        //}


        /* Implement a version of Guess My Number, where the computer randomly chooses a number between 1 and 1000, and the human guesses 
         * the number. In this case, the program should print a hint with each repetition, either <Your guess was too high>, <Your guess 
         * was too low>, or <You guessed the number>. The human should then input the next guess. Run this multiple times and compute the 
         * average number of repetitions necessary for you to guess the number. What is the maximum number of guesses you need to guess a 
         * number between 1 and 1000? Recall that log2 1000 = 9.966 and that 210 = 1024.*/

        public static void HumanPlays(int num)
        {

           int guess = Convert.ToInt32(Console.ReadLine());
           if (guess > num)
           {
               Console.WriteLine("\n\t Too High! Try again.");
               HumanPlays(num);
           }

           else if (guess < num)
           {
               Console.WriteLine("\n\t Too Low! Try again.");
               HumanPlays(num);
           }

           else
           {
               Console.WriteLine("\n\t It's about time you figured it out!");
           }
        
        }


        /*Implement a version of Guess My Number, where the human chooses a number between 1 and 100, and the computer guesses the number. 
        * The human should be able to tell the computer whether the computer’s guess was too high, too low, or was the correct answer. Run 
        * this multiple times and compute the average number of repetitions necessary for the computer to guess the number. Have the program 
        * print the value, the guess, and the list on each repetition. Is the human as good as the computer in finding the number? */

        static void ComputerPlays(int guess, int start, int end)
        {
            Console.WriteLine("\t Pick a number between 1-100 and I will guess what it is.");
            Console.WriteLine("\t Please respond with one of the following: " +
                "\n\t 1=Too high \n\t 2=Too low \n\t 3=You got it");
            Console.WriteLine("\t------------------------------------------------------------");
            Console.WriteLine($"\n\t I guess the number {guess}. Am I right?");

            string resp = Console.ReadLine();

            if (resp.ToLower() == "1")
            {
                end = guess - 1;
                guess = (end + start) / 2;
                ComputerPlays(guess, start, end);
            }
            else if (resp.ToLower() == "2")
            {
                start = guess + 1;
                guess = (end + start) / 2;
                ComputerPlays(guess, start, end);
            }
            else if (resp.ToLower() == "3")
            {
                Console.WriteLine("\n\t Congradulations!!!");
            }
            
        }
}   }
