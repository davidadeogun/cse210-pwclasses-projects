using System;
using System.Collections.Generic;
using System.Threading;
//For the exceeding requirement , I added an extra activity, MindfulWalking activity and also 
//Keeping a log of how many times activities were performed.

//I am literally having headache as I speak. 
namespace MindfulnessApp
{
    class Program
    {
        static Dictionary<string, int> activityCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine();

            while (true)
            {
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

                string input = Console.ReadLine();

                while (input != "1" && input != "2" && input != "3" && input!= "4" && input!= "5")
                {
                    Console.Write("Invalid input. Please select an activity: ");
                    input = Console.ReadLine();
                }

                if (input == "5")
                {
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    break;
                }

                Activity activity;
                switch (input)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new MindfulWalkingActivity();
                        break;
                    default:
                        activity = null;
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                    if (!activityCount.ContainsKey(activity.Name))
                    {
                        activityCount.Add(activity.Name, 1);
                    }
                    else
                    {
                        activityCount[activity.Name]++;
                    }
                }
                Console.WriteLine();
            }

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
    protected string _name;
    protected string _description;


    public string Name { get {return _name;} }
    public string Description { get {return _description;} }

    public void Run()
    {
        DisplayStartingMessage();
        Pause(3);
        DoActivity();
        Pause(3);
        DisplayEndingMessage();
        Pause(3);
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine("Starting " + Name + "...");
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

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job! You completed " + Name + " for " + _duration + " seconds.");
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

class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    

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


class ReflectionActivity : Activity
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

    public ReflectionActivity() : base()
    {
         _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

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

class ListingActivity : Activity
{
    private List<string> items = new List<string>();

    public ListingActivity() : base()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void DoActivity()
    {
        Console.WriteLine("Begin listing items. When you're finished, type 'done'.");
        Console.WriteLine();

        string item = "";
        while (item != "done" && _duration > items.Count)
        {
            item = Console.ReadLine();
            if (item != "done")
            {
                items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine("You listed " + items.Count + " items:");
        Console.WriteLine();
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + items[i]);
        }
    }
}


class MindfulWalkingActivity : Activity
{
    public MindfulWalkingActivity() : base()
    {
        _name = "Mindful Walking Activity";
        _description = "This activity will help you develop your ability to concentrate, and focus on one thing per time.";
    }

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
