using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        StartActivity();
        
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"\n{prompt}\n");
        
        Console.Write("You may begin in: ");
        DisplayCountdown(5);
        
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        
        while (DateTime.Now.Subtract(startTime).TotalSeconds < GetDuration())
        {
            Console.Write("\n> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        
        Console.WriteLine($"\n\nYou listed {items.Count} items!");
        
        EndActivity();
        
    }
}
