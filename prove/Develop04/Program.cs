using System;
using System.Collections.Generic;
using System.Threading;


// For the exceeding requirement, I added an activity count log and an additional Mindful Walking Activity as the 4th activity
namespace MindfulnessApp
{
    class Program
    {
        //Exceeding requirement: added an activity count log
        static Dictionary<string, int> activityCount = new Dictionary<string, int>(); // activity count log

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine();
            // Display menu options
            Console.WriteLine("Menu Options:");
            Console.WriteLine();
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Start mindful walking activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu:");
            Console.WriteLine();

            // Get user input
            string input = Console.ReadLine();

            // Validate input
            while (input != "1" && input != "2" && input != "3" && input!= "4" && input!= "5")
            {
                Console.Write("Invalid input. Please select an activity: ");
                input = Console.ReadLine();
            }

            //if the user wants to quit
            if (input == "5")
            {
                Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                return;
            }

            // Create activity based on user input
            Activity activity;
            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    Console.WriteLine("Welcome to the Breathing Activity.");
                    Console.WriteLine();
                    Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    Console.WriteLine("Welcome to the Reflection Activity.");
                    Console.WriteLine();
                    Console.WriteLine("This activity will help you reflect on a past experience that was meaningful to you. Choose one of the following prompts and spend the duration reflecting on it.");
                    break;
                case "3":
                    activity = new ListingActivity();
                    Console.WriteLine("Welcome to the Listing Activity.");
                    Console.WriteLine();
                    Console.WriteLine("This activity will help you clear your mind by listing out everything that comes to mind. Start by focusing on your breath and letting thoughts come and go. When a thought sticks, write it down and return to focusing on your breath.");
                    break;
                case "4":
                    activity = new MindfulWalkingActivity();
                    Console.WriteLine("Welcome to the Mindful Walking Activity.");
                    Console.WriteLine();
                    Console.WriteLine("This activity will help you develop your ability to concentrate, and focus on one thing per time.");
                    break;
                
                default:
                    activity = null;
                    break;
            }

            // Run activity
            if (activity != null)
            {
                activity.Run();
                //Exceeding requirement
                // Update activity count log
                if (!activityCount.ContainsKey(activity.GetType().Name))
                {
                    activityCount.Add(activity.GetType().Name, 1);
                }
                else
                {
                    activityCount[activity.GetType().Name]++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");

            // Print activity count log
            Console.WriteLine("Activity count log:");
            foreach (var entry in activityCount)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }
    }

    abstract class Activity
    {
        protected int _duration;

        public void Run()
        {
            DisplayStartingMessage();
            Pause(3);
            DoActivity();
            Pause(3);
            DisplayEndingMessage();
            Pause(3);
        }

       protected void DisplayStartingMessage()
{
    Console.WriteLine("Starting " + GetType().Name + "...");
    Console.WriteLine();
    Console.Write("How long, in seconds, would you like for your session? ");
    _duration = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Write("Get ready");
    for (int i = 0; i < 20; i++)
    {
        Console.Write(" +");
        
        Thread.Sleep(200);
    }
    Console.WriteLine();
    Pause(3);
}


        protected abstract void DoActivity();

        protected void DisplayEndingMessage()
        {   
            Console.WriteLine();
            Console.WriteLine("Good job! You completed " + GetType().Name + " for " + _duration + " seconds.");
        }

        protected void Pause(int seconds, bool displayTimer = true)
{
    if (displayTimer)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write("\r{0} ", new string(' ', Console.WindowWidth - 1));
            Console.Write("\r{0} seconds remaining", i);
            Thread.Sleep(1000);
        }
        Console.Write("\r{0}\r", new string(' ', Console.WindowWidth - 1));
    }
    else
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

    }

    class BreathingActivity : Activity  //derived from the base Activity
    {
        protected override void DoActivity()
        {
            
            for (int i = 0; i < _duration; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Breathe in...");
                }   
                else
                {   
                    Console.WriteLine();
                    Console.WriteLine("Breathe out...");
                }
                Pause(3);
            }
        }
    }

    class ReflectionActivity : Activity  //derived from the base Activity
    {
        private static List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
        };
           

    protected override void DoActivity()
    {
        
        int promptIndex = new Random().Next(prompts.Count);
        Console.WriteLine(prompts[promptIndex]);

        for (int i = 0; i < _duration; i++)
        {
            Console.Write("Reflecting");
            for (int j = 0; j < i % 3 + 1; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            Pause(1);
        }
        Console.WriteLine();
        Console.WriteLine("Now, answer one of the following questions to help deepen your reflection:");
        int questionIndex = new Random().Next(questions.Count);
        Console.WriteLine(questions[questionIndex]);
        string response = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Thank you for your reflection!");
    }
}

class ListingActivity : Activity //derived from the base Activity
{
    protected override void DoActivity()
    {
       
        List<string> items = new List<string>();
        for (int i = 0; i < _duration; i++)
        {
            Console.Write("Listing");
            for (int j = 0; j < i % 3 + 1; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            Pause(3);

            if (i % 10 == 0)
            {
                Console.WriteLine("Write down any thoughts that stuck with you:");
                string item = Console.ReadLine();
                items.Add(item);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Here are the items you listed:");
        foreach (string item in items)
        {
            Console.WriteLine("- " + item);
        }
    }
}


//Exceeding requirement: added another activity.
  class MindfulWalkingActivity : Activity  //derived from the base Activity
{
    protected override void DoActivity()
    {
        Console.WriteLine("Start walking slowly and mindfully. Take each step with intention and focus on the sensation of your feet touching the ground.");
        Pause(3);
        Console.WriteLine();
        Console.WriteLine("Notice the sensations in your body as you walk - the movement of your legs, the shifting of your weight, the rhythm of your breath.");
        Pause(3);
        Console.WriteLine();
        Console.WriteLine("If your mind starts to wander, gently bring your attention back to your breath and your steps.");
        Pause(3);
        Console.WriteLine();
        Console.WriteLine("Continue walking mindfully for the duration of the session.");
        Pause(_duration);
        Console.WriteLine();
    }
}

}