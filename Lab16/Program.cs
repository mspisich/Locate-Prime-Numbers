using System;
using System.Collections.Generic;

namespace Lab16
{
    class Program
    {
        //Store prime numbers found thus far. Initialize with primes up to 199.
        public static List<int> primeNumbers = new List<int>(new int[]{2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199});

        static void Main(string[] args)
        {
            Console.WriteLine("Let's locate some primes!");
            Console.WriteLine("\nThis application will find you any prime, in order, from first prime number on.");

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nWhich prime number are you looking for? (Huge numbers may take a while!)");

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
            
            //If prime numbers have been found before up to user input, use primeNumbers list. Otherwise, brute-force it.
            if (primeNumbers.Count >= userInput)
            {
                return primeNumbers[userInput - 1];
            }
            else
            {
                int primesSoFar = primeNumbers.Count;
                int priorPrimesTotal = primesSoFar;

                //Finding primes that aren't already in primeNumbers list. Start for loop at last index of list.
                //Add new prime numbers to list as they are found (except for initial 'i' value, since that's already in list!).
                for (int i = primeNumbers[primeNumbers.Count - 1]; primesSoFar <= userInput; i++)
                {
                    bool isPrime = CheckIfPrime(i);
                    if (isPrime == true && primesSoFar != priorPrimesTotal)
                    {
                        primeNumbers.Add(i);
                    }

                    if (isPrime == true)
                    {
                        primeNum = i;
                        primesSoFar++;
                    }
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
                Console.WriteLine("Goodbye.");
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
