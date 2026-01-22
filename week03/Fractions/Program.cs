using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------------------------------------
            // Exceeding Requirements:
            // 1. Implemented a library of scriptures instead of using a single hardcoded one.
            // 2. The program randomly selects a scripture from this library each time it runs.
            // 3. This allows the user to practice memorizing different scriptures.
            // -----------------------------------------------------------------------------------------
            
            List<Scripture> scriptureLibrary = new List<Scripture>();
            

            // Add scriptures to the library
            scriptureLibrary.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            scriptureLibrary.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
            scriptureLibrary.Add(new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."));

            
            // Select a random scripture
            Random random = new Random();
            int index = random.Next(scriptureLibrary.Count);
            Scripture scripture = scriptureLibrary[index];

            // Main loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                if (scripture.IsCompletelyHidden())
                {
                    break;
                }

                // Hide 3 words at a time
                scripture.HideRandomWords(3);
            }
        }
    }
}
