using System;
using System.Collections.Generic;

// Base class for all goals
class Goal
{
    internal string Description;

    public string Name { get; set; }
    public int PointsPerCompletion { get; set; }
    public int TotalPoints { get; set; }

    // This method is overriden by derived classes as needed
    public virtual string GetStatus()
    {
        return "";
    }

    // This method is called when the user records an event for this goal
    public virtual int RecordEvent()
    {
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }
}

// Simple goal that can be marked complete
class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            TotalPoints += PointsPerCompletion;
            return PointsPerCompletion;
        }
        else
        {
            return 0;
        }
    }
}

// Eternal goal that is never complete
class EternalGoal : Goal
{
    public int NumCompletions { get; set; }

    public override string GetStatus()
    {
        //return IsCompleted ? "[X]" : "[ ]";
        //return $"Completed {NumCompletions} times";
        return $"[ ]";
    }

    public override int RecordEvent()
    {
        NumCompletions++;
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }
}

// Checklist goal that must be accomplished a certain number of times
class ChecklistGoal : Goal
{
    public int TargetNumCompletions { get; set; }
    public int NumCompletions { get; set; }

    public override string GetStatus()
    {
        return $"Completed {NumCompletions}/{TargetNumCompletions} times";
    }

    // To create a new ChecklistGoal with a target of 3 completions:

    public override int RecordEvent()
{
    NumCompletions++;
    TotalPoints += PointsPerCompletion;

    int bonusPoints = 0;
    int completeAmount = TargetNumCompletions;

    if (NumCompletions == completeAmount)
    {
        TotalPoints += bonusPoints;
    }

    return PointsPerCompletion;
}

}

// Main program class
class Program
{
    static List<Goal> goals = new List<Goal>();

    public static string Description { get; private set; }

    static void Main()
    {
        Console.WriteLine("Welcome to the Eternal Quest program");
        Console.WriteLine();
        while (true)
        {
            int totalPoints = goals.Sum(goal => goal.TotalPoints);
            Console.WriteLine($"You have {totalPoints} points");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("Select a choice from the menu:");
            string choiceStr = Console.ReadLine();
            if (!int.TryParse(choiceStr, out int choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void CreateGoal()
{
    Console.WriteLine("The types of Goals are: ");

    Console.WriteLine("1. Simple goal");
    Console.WriteLine("2. Eternal goal");
    Console.WriteLine("3. Checklist goal");
    Console.WriteLine("What type of goal would you like to create?");

    string choiceStr = Console.ReadLine();
    if (!int.TryParse(choiceStr, out int choice))
    {
        Console.WriteLine("Invalid choice");
        return;
    }

    Goal goal;
    switch (choice)
    {
        case 1:
            goal = new SimpleGoal();
            break;
        case 2:
            goal = new EternalGoal();
            break;
        case 3:
            goal = new ChecklistGoal();
            break;
        default:
            Console.WriteLine("Invalid choice");
            return;
    }

    Console.Write("What is the name of the goal? ");
    goal.Name = Console.ReadLine();

    Console.Write("What is the goal description? ");
    goal.Description = Console.ReadLine();

    Console.Write("What is the amount of points associated with this goal? ");
    if (!int.TryParse(Console.ReadLine(), out int pointsPerCompletion))
    {
        Console.WriteLine("Invalid points");
        return;
    }
    goal.PointsPerCompletion = pointsPerCompletion;

    // Prompt for bonus information for ChecklistGoals
    if (goal is ChecklistGoal checklistGoal)
    {
        (int completeAmount, int bonusPoints) = PromptForBonus();
        checklistGoal.TargetNumCompletions = completeAmount;
        checklistGoal.PointsPerCompletion += bonusPoints;
    }

    goals.Add(goal);

}

    private static (int, int) PromptForBonus()
{
    Console.Write("How many times this goal needs to be accomplished for a bonus?");
    int completeAmount = int.Parse(Console.ReadLine());

    Console.Write("What is the bonus for accomplishing it that many times?");
    int bonusPoints = int.Parse(Console.ReadLine());

    return (completeAmount, bonusPoints);
}

    static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} {goal.Name} ({goal.Description})");
        }

        Console.WriteLine();
        int totalPoints = goals.Sum(goal => goal.TotalPoints);
        //Console.WriteLine($"You have {totalPoints} points");
        Console.WriteLine();
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(
                    $"{goal.GetType().Name},{goal.Name},{goal.PointsPerCompletion},{goal.TotalPoints}"
                );
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"simple,{simpleGoal.IsCompleted}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"eternal,{eternalGoal.NumCompletions}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine(
                        $"checklist,{checklistGoal.NumCompletions},{checklistGoal.TargetNumCompletions}"
                    );
                }
            }
        }
        // Console.WriteLine("Saved goals");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load goals from: ");
        string filename = Console.ReadLine();

        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string[] parts = reader.ReadLine().Split(',');
                if (parts.Length < 4)
                {
                    continue; // Skip empty or invalid lines
                }
                string typeName = parts[0];
                string name = parts[1];
                int pointsPerCompletion = int.Parse(parts[2]);
                int totalPoints = int.Parse(parts[3]);

                Goal goal;
                switch (typeName)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal();
                        string isCompletedStr = reader.ReadLine()?.Split(',')[1];
                        if (isCompletedStr != null)
                        {
                            ((SimpleGoal)goal).IsCompleted = bool.Parse(isCompletedStr);
                        }
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal();
                        string numCompletionsStr = reader.ReadLine()?.Split(',')[1];
                        if (numCompletionsStr != null)
                        {
                            ((EternalGoal)goal).NumCompletions = int.Parse(numCompletionsStr);
                        }
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal();
                        string numCompletionsStr2 = reader.ReadLine()?.Split(',')[1];
                        string targetNumCompletionsStr = reader.ReadLine()?.Split(',')[2];
                        if (numCompletionsStr2 != null && targetNumCompletionsStr != null)
                        {
                            ((ChecklistGoal)goal).NumCompletions = int.Parse(numCompletionsStr2);
                            ((ChecklistGoal)goal).TargetNumCompletions = int.Parse(
                                targetNumCompletionsStr
                            );
                        }
                        break;
                    default:
                        throw new Exception("Unknown goal type");
                }

                goal.Name = name;
                goal.Description = Description;
                goal.PointsPerCompletion = pointsPerCompletion;
                goal.TotalPoints = totalPoints;
                goals.Add(goal);
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Loaded from {filename}. The goals are: ");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(
                $"{goal.GetType().Name}: {goal.Name} ({goal.Description}) - {goal.TotalPoints} points"
            );
            Console.WriteLine();
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Which goal did you complete?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        string choiceStr = Console.ReadLine();
        if (!int.TryParse(choiceStr, out int choice))
        {
            Console.WriteLine("Invalid choice");
            return;
        }
        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid choice");
            return;
        }

        Goal goal = goals[choice - 1];
        int points = goal.RecordEvent();
        Console.WriteLine($"Congratulations! You have earned {points} points");
    }
}
