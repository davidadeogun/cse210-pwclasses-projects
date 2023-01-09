using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)


    {                 
        //Display the result of the variable (number) to the console / terminal
    //while loop
        string input = "yes";
        while (input == "yes")
        {
            Console.WriteLine("EXAMPLE 1");
            Console.Write("Do you want to continue? ");
            input = Console.ReadLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        //do while loop
        do
        {
            Console.WriteLine("EXAMPLE 2");
            Console.Write("How do you want it? ");
            input = Console.ReadLine();
        } while (input == "yes");

        Console.WriteLine();
        Console.WriteLine();
        //For Loops
        Console.WriteLine("EXAMPLE 3");
        //i = i +2 do this by an increment of 2
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine();

        //Foreach Loops
        List<string> colors = new List<string>();
        colors.Add("white");
        colors.Add("pink");
        colors.Add("black");

        Console.WriteLine("EXAMPLE 4");
        foreach (string color in colors)
        {
            Console.WriteLine(color);
        }
        Console.WriteLine();
        //Random Numbers
        Console.WriteLine("EXAMPLE 5");

        //ASSIGNEMT - GUESS THE MAGIC NUMBER
        

        //Instead of having the user supply the magic number, generate a random number from 1 to 5.
        //Random randomNumGenerator = new Random();
        //int 
        Random randomNumberGenerator  = new Random();
        int magicNumber = randomNumberGenerator.Next(1,10);
        

        int guessNumber = -1;

        while (guessNumber != magicNumber)
        {
            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());

            if (guessNumber < magicNumber)
            {
                Console.WriteLine("Guess higher");

            }
            else if (guessNumber > magicNumber)
            {
                Console.WriteLine("Guess lower");
            }
            else {
                Console.WriteLine("Yay! You guessed right");
            }
        }

        
            }
        



    }
