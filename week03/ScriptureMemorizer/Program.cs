using System;


class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        RunMemorizationSession(scripture);
    }

    /// <summary>
    /// Runs a memorization session for a given scripture.
    /// </summary>
    /// <param name="scripture">The scripture to memorize</param>
    static void RunMemorizationSession(Scripture scripture)
    {
        while (true)
        {
            // Clear console and display scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nProgress: {scripture.GetHiddenWordCount()}/{scripture.GetWordCount()} words hidden");

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCongratulations! You have hidden all the words. Great memorization practice!");
                break;
            }

            // Prompt user
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            // Check if user wants to quit
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Thank you for practicing! Keep up the memorization!");
                break;
            }

            // Hide a random word
            scripture.HideRandomWord();
        }
    }
}