using System;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"Description: {_description}\n");
        
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nPrepare to begin...");
        DisplayAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!!");
        DisplayAnimation(2);
        
        Console.WriteLine($"\nYou have completed another {_name} Activity that lasted {_duration} seconds.");
        DisplayAnimation(3);
    }

    protected void DisplayAnimation(int seconds)
    {
        int totalMilliseconds = seconds * 1000;
        int intervalMilliseconds = 500;
        string[] spinner = { "|", "/", "-", "\\" };
        int spinIndex = 0;

        DateTime startTime = DateTime.Now;
        while (DateTime.Now.Subtract(startTime).TotalMilliseconds < totalMilliseconds)
        {
            Console.Write(spinner[spinIndex]);
            System.Threading.Thread.Sleep(intervalMilliseconds);
            Console.Write("\b \b");
            spinIndex = (spinIndex + 1) % spinner.Length;
        }
        Console.WriteLine();
        
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }
}
