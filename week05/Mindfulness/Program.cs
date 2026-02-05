using System;

// CREATIVITY ENHANCEMENT:
// This program tracks user activity sessions and displays stats at the end.
// It keeps count of how many times each activity has been performed during the session.

class Program
{
    private static int _breathingCount = 0;
    private static int _reflectionCount = 0;
    private static int _listingCount = 0;

    static void Main(string[] args)
    {
        bool running = true;
        
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program\n");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect an option (1-4): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    RunBreathingActivity();
                    _breathingCount++;
                    break;
                case "2":
                    RunReflectionActivity();
                    _reflectionCount++;
                    break;
                case "3":
                    RunListingActivity();
                    _listingCount++;
                    break;
                case "4":
                    DisplaySessionStats();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }
    

    static void RunBreathingActivity()
    {
        BreathingActivity activity = new BreathingActivity();
        activity.Run();
        PauseAfterActivity();
    }

    static void RunReflectionActivity()
    {
        ReflectionActivity activity = new ReflectionActivity();
        activity.Run();
        PauseAfterActivity();
    }

    static void RunListingActivity()
    {
        ListingActivity activity = new ListingActivity();
        activity.Run();
        PauseAfterActivity();
    }

    static void PauseAfterActivity()
    {
        Console.Write("\nPress enter to return to the menu...");
        Console.ReadLine();
    }

    static void DisplaySessionStats()
    {
        Console.Clear();
        Console.WriteLine("Session Statistics:");
        Console.WriteLine($"Breathing Activities: {_breathingCount}");
        Console.WriteLine($"Reflection Activities: {_reflectionCount}");
        Console.WriteLine($"Listing Activities: {_listingCount}");
        Console.WriteLine($"Total Activities: {_breathingCount + _reflectionCount + _listingCount}");
        Console.WriteLine("\nThank you for using the Mindfulness Program. Keep taking care of yourself!");
    }
}