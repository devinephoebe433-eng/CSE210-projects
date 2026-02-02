using System;

/// <summary>
/// Scripture Memorizer Program
/// 
/// This program helps users memorize scriptures by displaying them and progressively
/// hiding random words with underscores, allowing users to practice recitation.
/// 
/// CREATIVITY AND EXCEEDING REQUIREMENTS:
/// 1. Scripture Library: The program includes a library of 8 diverse scriptures instead of
///    just one. Users can practice different scriptures in each session for variety and
///    broader memorization practice.
/// 2. Random Scripture Selection: Each program run selects a random scripture from the
///    library, providing different content each time the user runs the program.
/// 3. Enhanced User Feedback: The program displays progress (words hidden/total words)
///    to help users track their memorization progress through each scripture.
/// 4. Multi-verse Support: Scriptures include both single verses and verse ranges to
///    demonstrate comprehensive reference handling.
/// 5. Professional Encapsulation: All four required classes (Word, Reference, Scripture,
///    and ScriptureLibrary) maintain strict encapsulation with private members and
///    proper getter methods. Each class has a single, well-defined responsibility.
/// </summary>
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