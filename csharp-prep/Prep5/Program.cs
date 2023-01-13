using System;

class Program
{
    static void Main(string[] args)  // This is the syntax of the default main function
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName(); // call the function in the Main and assign it to a variable
        int userNumber = PromptUserNumber();  //call the PromptUserNumber function and assign it to integer variable (userNumber)

        int squaredNumber = SquareNumber(userNumber);  //call the SquareNumber function and pass the userNumber as the parameter.
                                                       //Any number that the user entered in the PromptUserNumber is calculated in the SqaureNumber function

        DisplayResult(userName, squaredNumber); //the DisplayResult function is called in the Main function and the userName and squaredNumber are passed as values.
                                                //In the function DisplayResult , the parameters are name and square
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()  // This function will expected to return a integer value
    {
        Console.Write("Please enter your favorite number: ");  //Ask the user for a favourite number
        int number = int.Parse(Console.ReadLine());    //Read the line and parse the value as an integer and assign it to a integer number variable

        return number;    //return the variable
    }

    static int SquareNumber(int number)   //a function that accepts a parameter
    {
        int square = number * number;   //performs a calculation and returns the square variable
        return square;
    }

    static void DisplayResult(string nameName, int squareSquare)  //Accepts two parameters. The parameters can be anything such as name, nameName, namiMani
    {                                                             // The parameters don't have to have the return names in the PromptUserName and PromptUserNumber functions
        Console.WriteLine($"{nameName}, the square of your number is {squareSquare}");
    }
}
