using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's locate some primes!");
            Console.WriteLine("/nThis application will find you any prime, in order, from first prime number on.");

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nWhich prime number are you looking for?");

                int input = -1;
                bool isValid = false;

                //Get and verify input
                do
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if(input < 1)
                        {
                            throw new IndexOutOfRangeException();
                        }
                                            
                        isValid = true;
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Input must be a whole number! Try again:");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Number must be 1 or greater! Try again:");
                    }
                } while (isValid == false);

                int primeNum = FindPrimeAt(input);

                Console.WriteLine("The number " + input + " prime is " + primeNum + ".");

                Console.WriteLine("\nDo you want to find another prime number? (y/n):");
                run = Continue();
            }  
        }
        
        //Find prime number at chosen location
        public static int FindPrimeAt(int userInput)
        {
            int primeNum = -1;
            int primesSoFar = 0;
            
            for (int i = 0; primesSoFar < userInput; i++)
            {
                bool isPrime = CheckIfPrime(i);
                if(isPrime == true)
                {
                    primeNum = i;
                    primesSoFar++;
                }
            }

            return primeNum;
        }

        public static bool CheckIfPrime(int inputNum)
        {
            //Return false for numbers divisible by 2 or 3, or numbers 1 or less
            //2 and 3 are prime and return true
            if (inputNum <= 1)
            {
                return false;
            }
            else if (inputNum <= 3)
            {
                return true;
            }
            else if (inputNum % 2 == 0 && inputNum % 3 == 0)
            {
                return false;
            }

            //Check all other numbers up to user input
            int numberOfFactors = 0;

            for (int i = 2; i <= inputNum; i++)
            {
                if (inputNum % i == 0)
                {
                    numberOfFactors++;
                }
            }

            if (numberOfFactors > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Continue program?
        public static bool Continue()
        {
            string input = Console.ReadLine().ToLower();
            bool run = false;

            if (input.Equals("n"))
            {
                run = false;
            }
            else if (input.Equals("y"))
            {
                run = true;
            }
            else
            {
                Console.WriteLine("\nInvalid input! Please type y/n:");
                run = Continue();
            }

            return run;
        }
    }
}
