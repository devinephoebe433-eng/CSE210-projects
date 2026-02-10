using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            int level = GetLevel(_score);
            Console.WriteLine("\n╔═════════════════════════════════════╗");
            Console.WriteLine($"║ Eternal Quest: Level {level} - {GetRank(level)}");
            Console.WriteLine($"║ Score: {_score} points");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Record Progress");
            Console.WriteLine("3. Create a New Goal");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ListGoalDetails();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Thanks for using Eternal Quest! Keep working towards your goals!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\n========== Your Goals ==========");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one to get started!");
        }
        else
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }
        Console.WriteLine();
        DisplayScore();
        Console.WriteLine("================================");
    }

    private void DisplayScore()
    {
        int level = GetLevel(_score);
        string rank = GetRank(level);
        Console.WriteLine($"Total Score: {_score} points | Level {level} - {rank}");
    }

    private int GetLevel(int score)
    {
        return Math.Max(1, (score / 500) + 1); // Level up every 500 points
    }

    private string GetRank(int level)
    {
        return level switch
        {
            1 => "Beginner",
            2 => "Learner",
            3 => "Practitioner",
            4 => "Warrior",
            5 => "Champion",
            6 => "Sage",
            7 => "Master",
            8 => "Grand Master",
            _ => "Eternal Rishi"
        };
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create a goal first!");
            return;
        }

        Console.WriteLine("\nEnter the number of the goal you completed:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int oldLevel = GetLevel(_score);
        int pointsEarned = _goals[choice - 1].RecordEvent();
        _score += pointsEarned;
        int newLevel = GetLevel(_score);

        Console.WriteLine($"\nProgress recorded! You earned {pointsEarned} points!");

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"\n✨ LEVEL UP! You are now Level {newLevel} - {GetRank(newLevel)}! ✨");
        }

        if (_goals[choice - 1].IsComplete())
        {
            Console.WriteLine($"🎯 Goal '{_goals[choice - 1].GetName()}' is now complete!");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple (Complete once, then done)");
        Console.WriteLine("2. Eternal (Repeats forever, never complete)");
        Console.WriteLine("3. Checklist (Must complete X times)");
        Console.WriteLine("4. Progress (Work towards a large goal)");
        Console.WriteLine("5. Bad Habit (Lose points each time)");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                Console.Write("Enter goal target (e.g., 10 for 10 km run): ");
                int goalTarget = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, description, points, goalTarget));
                break;
            case "5":
                _goals.Add(new BadHabitGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        Console.WriteLine("Goal created!");
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(",");
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        break;
                    case "ProgressGoal":
                        _goals.Add(new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]), double.Parse(parts[4]), double.Parse(parts[5])));
                        break;
                    case "BadHabitGoal":
                        _goals.Add(new BadHabitGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}