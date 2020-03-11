using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumber_Bisection
{
    class Program
    {
        private static bool Bisection_Search1(int value, int[] list)
        {
            Console.WriteLine($"The array is {ArrayToString(list)}.");
            int middle = list[(list.Length - 1) / 2];
            Console.WriteLine($"The middle value is {middle}.");
            if (value == middle)
            {
                return true;
            }
            else if (value > middle)
            {
                return Bisection_Search1(value, list.Skip<int>(list.Length / 2).ToArray());
            }
            else if (value < middle)
            {
                return Bisection_Search1(value, list.Take<int>(list.Length / 2).ToArray());
            }
            return false;
        }
        private static string ArrayToString(int[] list)
        {
            string retval = "{";

            for (int i = 0; i < list.Length - 1; i++)
            {
                retval += list[i] + ",";
            }

            retval += list[list.Length - 1];

            return retval + "}";
        }
        public static int GetValidInput1()
        {
            int value = 0;

            while (value < 1 | value > 10)
            {
                string line = Console.ReadLine();

                int temp;

                if (int.TryParse(line, out temp))
                {
                    if (temp < 1 | temp > 10)
                    {
                        Console.WriteLine("Invalid number.");
                    }

                    value = temp;
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                }
            }
            return value;
        }
        private static bool GuessMyNumber1(int computerNumber)
        {
            Console.Write("Guess my number: ");
            int guess = GetValidInput2();

            if (guess == computerNumber)
            {
                Console.WriteLine("<You guessed the number>");
                return true;
            }
            else if (guess > computerNumber)
            {
                Console.WriteLine("<Your guess was too high>");
                return GuessMyNumber1(computerNumber);
            }
            else if (guess < computerNumber)
            {
                Console.WriteLine("<Your guess was too low>");
                return GuessMyNumber1(computerNumber);
            }
            return false;
        }
        public static int GetValidInput2()
        {
            int value = 0;

            while (value < 1 | value > 1000)
            {
                string line = Console.ReadLine();

                int temp;

                if (int.TryParse(line, out temp))
                {
                    if (temp < 1 | temp > 1000)
                    {
                        Console.WriteLine("Invalid number.");
                    }

                    value = temp;
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                }
            }
            return value;
        }
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private static bool GuessMyNumber2(int value, int[] list)
        {
            Console.WriteLine($"Your number is {value}.");
            int computerGuess = list[(list.Length - 1) / 2];
            Console.WriteLine($"The computer's guess is {computerGuess}.");
            Console.WriteLine($"The list is {ArrayToString(list)}.");
            Console.WriteLine("Give the computer a hint*[1-Too High]=[2=Too Low]=[3=Correct Answer]*");

            return Bisection_Search2(value, computerGuess, list);
        }
        private static bool Bisection_Search2(int value, int computerGuess, int[] list)
        {
            string hint = Console.ReadLine();
            if (hint == "3")
            {
                return true;
            }
            else if (hint == "1")
            {
                return GuessMyNumber2(value, list.Take<int>(list.Length / 2).ToArray());
            }
            else if (hint == "2")
            {
                return GuessMyNumber2(value, list.Skip<int>(list.Length / 2).ToArray());
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return GuessMyNumber2(value, list);
            }
        }
        public static int GetValidInput3()
        {
            Console.WriteLine("Enter a number between 1 and 100.");

            int value = 0;

            while (value < 1 | value > 100)
            {
                string line = Console.ReadLine();

                int temp;

                if (int.TryParse(line, out temp))
                {
                    if (temp < 1 | temp > 100)
                    {
                        Console.WriteLine("Invalid number.");
                    }

                    value = temp;
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                }
            }
            return value;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for a demonstration of bisection. 2 to guess the computer's number between 1 and 1,000. 3 to have the computer guess your number between 1 and 100.");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                Console.WriteLine("Enter a number between 1 and 10.");
                int value = GetValidInput1();

                if (Bisection_Search1(value, list) == true)
                {
                    Console.WriteLine($"The value being searched for, {value}, was found.");
                }
            }
            if (userInput == "2")
            {
                int computerNumber = RandomNumber(1, 1000);
                GuessMyNumber1(computerNumber);
            }
            if (userInput == "3")
            {
                int[] list = Enumerable.Range(1, 100).ToArray();

                //int computerGuess = 0;

                int value = GetValidInput3();

                GuessMyNumber2(value, list);
            }
            else
            {
                Main(args);
            }
        }
    }
}
