using System;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. Added a 'Clear' option (Menu choice 5) to wipe the current session's memory without deleting files.
 * 2. Included a safety check in the Journal.LoadFromFile method to handle empty or corrupted lines.
 * 3. Expanded the prompt list to include more thought-provoking personal reflection questions.
 */

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        
        // choice is a local variable, so it uses camelCase
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != "6")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Clear Current Journal"); // Creativity addition
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                // Creating a new Entry object using the constructor
                Entry newEntry = new Entry(date, prompt, response);
                myJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (userChoice == "5")
            {
                // Logic for the creativity requirement
                myJournal._entries.Clear();
                Console.WriteLine("Journal cleared from memory.");
            }
        }

        Console.WriteLine("Farewell. Keep writing!");
    }
}