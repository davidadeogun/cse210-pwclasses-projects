internal class Program
{
    private static void Main(string[] args)
    {
        string name = "Funke";
        if (name == "John")
        {
            Console.WriteLine("The name is John");
        }
        else if (name == "Diana")
        {
            Console.WriteLine("Her name is Diana");
        }
        else
        {
            Console.WriteLine("None of these names exist");
        }

        string color = "Pink";
        if (color != "green")
        {
            Console.WriteLine("Color is not pink");
        }
        else
        {
            Console.WriteLine("Her favorite color is pink");
        }

        int x = 9;
        int y = 5;

        if(x > y)
        {
            Console.WriteLine("x is greater than y");
        }
        else
        {
            Console.WriteLine("y is greater than x");
        }
        if (x == 9 && y == 5)
        {
            Console.WriteLine("Yes, they are the same!");
        }
        if (x == 9 || y == 5)
        {
            Console.WriteLine("Yay! They are the children of the same mother!");
        }

        Console.Write("What is your favourite number? ");  /*Console.Write is like input in python*/
        string userInput = Console.ReadLine();     /*Like storing a value*/
        int number = int.Parse(userInput);   /*Parse function is converting a string data type to integer in python*/
        Console.WriteLine($"Your number is {number}");   /*Console.WriteLine is like a print statement in python*/

        /*THE WEEK 1 PREP 2 ASSIGNMENT*/
        Console.Write("What is your grade percentage? ");
        string gradeString = Console.ReadLine();
        int gradeNumber = int.Parse(gradeString);
        
        string letter = "";
    
        if (gradeNumber >= 90)
        {
            letter = "A";
        }
        else if (gradeNumber >= 80)
        {
            letter = "B";
        }
        else if (gradeNumber >= 70)
        {
            letter = "C";
        }
        else if (gradeNumber >= 60)
        {
            letter = "D";
        }
        else
        {
            Console.WriteLine("You got an F!");
        }

        Console.WriteLine($"Your grade is {letter}");

        if (gradeNumber >= 70)
        {
            Console.WriteLine("Congratualtions!.You passed!");

        }
        else
        {
            Console.WriteLine("Buckle up next time!");
        }
        


        
    }
}