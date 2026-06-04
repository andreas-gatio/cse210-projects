using System;
using System.Collections.Generic;
using System.Threading;

/* CREATIVITY: this is a fourth activity that I added on my own (it is not one
   of the three required ones). It has the user list things they are grateful
   for, and at the end it picks one of their answers at random and tells them
   to carry that one with them today. It still inherits everything from Activity. */
public class GratitudeActivity : Activity
{
    private List<string> _prompts;

    public GratitudeActivity()
    {
        _name = "Gratitude Activity";
        _description = "This activity will help you slow down and notice the good things by listing what you are grateful for. At the end it will pick one of your answers for you to carry with you today.";

        _prompts = new List<string>();
        _prompts.Add("What is something small that made you smile today?");
        _prompts.Add("Who is someone you are thankful to have in your life?");
        _prompts.Add("What is something about your body or health you are grateful for?");
        _prompts.Add("What is a place that you feel peaceful in?");
        _prompts.Add("What is something you usually take for granted?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Think about the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("List the things you are grateful for (press enter after each one):");

        /* collect the user's answers until their time runs out. */
        List<string> answers = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                answers.Add(item);
            }
        }

        /* if they listed anything, pick one at random to leave them with. */
        if (answers.Count > 0)
        {
            Random random = new Random();
            string carry = answers[random.Next(answers.Count)];
            Console.WriteLine();
            Console.WriteLine($"Out of everything you listed, carry this one with you today:");
            Console.WriteLine($"   \"{carry}\"");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }

    /* pick one random prompt from the list. */
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
