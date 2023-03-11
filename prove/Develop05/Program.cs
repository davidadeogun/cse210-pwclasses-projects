using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


//Exceeding requirement. The user is presented with an option to delete a goal
//In reality, what if we had no option to correct a mistake in a program.
//I shop for groceries, and sometimes I feel like I don't need a product anymore 
//at the counter. So, I delete it from my cart. The same thing happens here in the program.
//That is my exceeding requirement, it may look simple but it is powerful.

// Main program class
class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {   Console.WriteLine();
        Console.WriteLine("Welcome to the Goal Tracking program");
        Console.WriteLine();
//Menu Options
        while (true)
        {
            int totalPoints = goals.Sum(goal => goal._totalPoints);
            Console.WriteLine($"You have {totalPoints} points");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Delete goal");  //Exceeding requirment. The user should have the option of deletinga goal
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Record event");
            Console.WriteLine("7. Quit");
            

            Console.Write("Select a choice from the menu: ");
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
                    DeleteGoal();  //Exceeding requirement
                    break;
                   
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    RecordEvent();
                    break;
                case 7:
                    return;
                

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

//Create Goals
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

        Goal goal = null;
        switch (choice)
        {
            case 1:
                goal = new SimpleGoal("", "", 0, false);
                break;
            case 2:
                goal = new EternalGoal("", "", 0, 0);
                break;
            case 3:
                goal = new ChecklistGoal("", "", 0, 0, 0, 0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        Console.Write("What is the name of the goal? ");
        goal._name = Console.ReadLine();

        Console.Write("What is the goal description? ");
        goal._description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int pointsPerCompletion))
        {
            Console.WriteLine("Invalid points");
            return;
        }
        goal._pointsPerCompletion = pointsPerCompletion;

        // Prompt for bonus information for ChecklistGoals
        if (goal is ChecklistGoal checklistGoal)
        {
            (int completeAmount, int bonusPoints) = PromptForBonus();
            checklistGoal._targetNumCompletions = completeAmount;
            checklistGoal._bonusPoints = bonusPoints;
        }

        goals.Add(goal);
    }


//Prompt for Bonus-  Checklist only
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
            Console.Write($"{goal.GetStatus()} {goal._name} ({goal._description})");

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write(
                    $" --- Currently completed {checklistGoal._numCompletions}/{checklistGoal._targetNumCompletions} times"
                );
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        int totalPoints = goals.Sum(goal => goal._totalPoints);
        Console.WriteLine($"You have {totalPoints} points");
        Console.WriteLine();
    }

//DeleteGoals  - - -Exceeded requirements
    static void DeleteGoal()
    {
        Console.WriteLine("Which goal would you like to delete?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]._name}");
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
        goals.Remove(goal);
        Console.WriteLine($"{goal._name} has been deleted.");
    }

//SaveGoals
    static void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                string goalString = goal.ToDataString();
                writer.WriteLine(goalString);
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    

 //Load Goals
    static void LoadGoals()
    {
        Console.Write("Enter filename to load goals from: ");
        string filename = Console.ReadLine();

        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            int lineNumber = 0;
            while (!reader.EndOfStream)
            {
                lineNumber++;
                string[] parts = reader.ReadLine().Split(',');
                if (parts.Length < 5)
                {
                    continue; // Skip empty or invalid lines
                }
                string typeName = parts[0];
                string name = parts[1];
                string description = parts[2];
                int pointsPerCompletion = int.Parse(parts[3]);
                int totalPoints = int.Parse(parts[4]);

                Goal goal;
                switch (typeName)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, pointsPerCompletion);
                        if (parts.Length > 5)
                        {
                            string isCompletedStr = parts[5];
                            if (isCompletedStr != null)
                            {
                                ((SimpleGoal)goal)._IsCompleted = bool.Parse(isCompletedStr);
                            }
                        }
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, pointsPerCompletion, 0);
                        if (parts.Length > 5)
                        {
                            string numCompletionsStr = parts[5];
                            if (numCompletionsStr != null)
                            {
                                ((EternalGoal)goal)._numCompletions = int.Parse(numCompletionsStr);
                            }
                        }
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(name, description, pointsPerCompletion, 0, 0);
                        if (parts.Length > 6)
                        {
                            string numCompletionsStr2 = parts[5];
                            string targetNumCompletionsStr = parts[6];
                            if (numCompletionsStr2 != null && targetNumCompletionsStr != null)
                            {
                                ((ChecklistGoal)goal)._numCompletions = int.Parse(
                                    numCompletionsStr2
                                );
                                ((ChecklistGoal)goal)._targetNumCompletions = int.Parse(
                                    targetNumCompletionsStr
                                );
                            }
                        }
                        break;
                    default:
                        throw new Exception("Unknown goal type");
                }

                goal._totalPoints = totalPoints;
                goals.Add(goal);
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Loaded from {filename} ");
        Console.WriteLine("The goals are:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goal.GetType().Name}: {goal._name} - {goal._totalPoints} points");
        }
    }

//Record event
    static void RecordEvent()
    {
        Console.WriteLine("Which goal did you complete?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]._name}");
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

        // SaveGoals(); not necessary
    }



}
