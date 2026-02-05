using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        StartActivity();
        
        DateTime startTime = DateTime.Now;
        while (DateTime.Now.Subtract(startTime).TotalSeconds < GetDuration())
        {
            Console.WriteLine("\nBreathe in...");
            DisplayCountdown(4);
            
            if (DateTime.Now.Subtract(startTime).TotalSeconds >= GetDuration())
                break;
            
            Console.WriteLine("\nBreathe out...");
            DisplayCountdown(4);
        }
        
        EndActivity();
    }
}
