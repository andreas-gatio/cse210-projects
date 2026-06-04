using System;
using System.Collections.Generic;
using System.Threading;

/* the reflecting activity shows the user a random prompt and then keeps
   asking random questions about it (with a spinner pause in between) until
   their time runs out. it inherits everything from Activity. */
public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        /* the prompts give the user something to think about. */
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        /* the questions help them reflect more deeply on that prompt. */
        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    /* pick one random prompt from the list. */
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    /* pick one random question from the list. */
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    /* show one random prompt on the screen. */
    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    /* keep showing random questions with a spinner pause until time is up. */
    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
    }
}
