using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

//Improved on the design to develop the program
class Program
{
    static void Main()
    {
        UserJournal journal = new UserJournal();
        Console.WriteLine("Welcome to the Journal Program");  //Displays once, does not loop
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine("Menu");  //Menu options
            Console.WriteLine("1. Create new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Select from the menu options: ");


            //Converts user's entry to an integer
            int choice = int.Parse(Console.ReadLine());

            //If user's choice is 1, it creates new entry as specified in the menu
            Console.WriteLine();
            if (choice == 1)
            {
                journal.NewEntry();
            }
            else if (choice == 2)
            {
                journal.DisplayJournal();
            }
            else if (choice == 3)
            {
                Console.Write("Enter a filename: "); //If the user picks Option 3, it asks for the filename
                string filename = Console.ReadLine();
                journal.SaveJournal(filename);
                Console.WriteLine("Journal saved to " + filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter a filename: ");
                string filename = Console.ReadLine();
                journal.LoadJournal(filename);
                Console.WriteLine("Journal loaded from " + filename);
            }
            else if (choice == 5)
            {
                break;
            }
        }
    }
}


class UserEntry   //The 1st class
{
    public string _promptUser;
    public string _responseUser;
    public DateTime _dateUser;

    public string _locationUser;   //Exceeding requirement. Added location to the list of properties that asks the location where the entry was made

    //Create a new object of the Entry type, means defining a constructor and assigning those values
    public UserEntry(string prompt, string response, DateTime date, string location)
    {
        this._promptUser = prompt;  //Optional to use this._promptUser, could always _promptUser = prompt; 
        this._responseUser = response;
        this._dateUser = date;
        this._locationUser = location;  // Exceeding requirement
    }
}

class UserJournal   //The 2nd class - meets minimum requirement
{
    private List<UserEntry> entries = new List<UserEntry>();

    //Creates a list of prompts
    public List<string> prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What are you mostly grateful for?",
        "What would have accomplished by the end of the week?"
    };

    /*NewEntry() method in the Journal class is used to create a new journal entry.
     It randomly selects a prompt from the list of prompts and prompts the user to enter a response. 
     It also prompts the user to enter the location where the entry was made,
      and it saves that information as a property of the Entry object.*/
    public void NewEntry()
    {
        Random rnd = new Random();
        int promptIndex = rnd.Next(prompts.Count);
        string prompt = prompts[promptIndex];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        // Exceeding requirement
        //To exceed the requirement , I asked the user where the entry was made. 
        //The location of the answer was saved.
        //Added location property

        Console.WriteLine("Where did you make this entry? ");
        string location = Console.ReadLine();
        UserEntry entry = new UserEntry(prompt, response, DateTime.Now, location);
        entries.Add(entry);
    }

    /*The DisplayJournal() method in the Journal class is used to display 
    all journal entries to the user. It loops through the list of Entry objects
     and displays the prompt, response, date and location of each entry.*/
    public void DisplayJournal()
    {
        foreach (UserEntry entry in entries)
        {
            Console.WriteLine("Prompt: " + entry._promptUser);
            Console.WriteLine("Response: " + entry._responseUser);
            Console.WriteLine("Date: " + entry._dateUser);
            Console.WriteLine("Location: " + entry._locationUser); // Exceeding requirement
            Console.WriteLine();
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (UserEntry entry in entries)
            {
                writer.WriteLine(entry._promptUser);
                writer.WriteLine(entry._responseUser);
                writer.WriteLine(entry._dateUser);
                writer.WriteLine(entry._locationUser); // Exceeding requirement
            }
        }
    }


    /* LoadJournal(string filename) method in the Journal class is used
     to load journal entries from a file. It creates a new StreamReader
      object and reads the prompt, response, date and location of each entry
       from the file, and it then creates new Entry objects for each entry,
        adding them to the list of entries.*/
    public void LoadJournal(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                string dateString = reader.ReadLine();
                string location = reader.ReadLine();  // Exceeding requirement
                DateTime date = DateTime.Parse(dateString);
                UserEntry entry = new UserEntry(prompt, response, date, location);
                entries.Add(entry);
            }
        }
    }



}



