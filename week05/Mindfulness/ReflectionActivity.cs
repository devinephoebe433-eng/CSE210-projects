using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity() : base("Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            
        };
    }

    public void Run()
    {
        StartActivity();
        
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine(prompt);
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("Press enter when ready to begin");
        DisplayAnimation(3);

        DateTime startTime = DateTime.Now;
        while (DateTime.Now.Subtract(startTime).TotalSeconds < GetDuration())
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine("\n" + question);
            DisplayAnimation(5);
        }
        
        EndActivity();
    }
}
