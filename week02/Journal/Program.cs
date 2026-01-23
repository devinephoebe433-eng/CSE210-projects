using System;


/// <summary>
/// Journal Program - Helps users record daily events with prompts
/// 
/// CREATIVITY FEATURES IMPLEMENTED:
/// 1. Extended Prompt List: Added 10 unique prompts instead of just 5 to provide more variety
/// 2. Entry Counter: Shows user how many entries are in the journal
/// 3. Error Handling: Comprehensive try-catch blocks for file operations
/// 4. Separator-based Format: Uses ~|~ separator for reliable save/load operations
/// 5. Automatic Date Tracking: Captures current date automatically with ToShortDateString()
/// 6. User Feedback: Clear messages on save/load success with entry count
/// </summary>
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("\n========================================");
        Console.WriteLine("     Welcome to the Journal Program");
        Console.WriteLine("========================================\n");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!\n");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.\n");
                    break;
            }
        }
    }


    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    static void DisplayMenu()
    {
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("Enter your choice: ");
    }

    /// <summary>
    /// Prompts the user to write a new journal entry.
    /// </summary>
    static void WriteNewEntry(Journal journal)
    {
        Console.WriteLine();
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved!\n");
    }

    /// <summary>
    /// Prompts the user for a filename and saves the journal.
    /// </summary>
    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save: ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.\n");
            return;
        }

        journal.SaveToFile(filename);
    }


    /// <summary>
    /// Prompts the user for a filename and loads the journal.
    /// </summary>
    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.\n");
            return;
        }

        journal.LoadFromFile(filename);
    }
}