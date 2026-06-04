using System;
using System.Collections.Generic;
using System.Threading;

/* the listing activity gives the user a prompt and has them list as many
   things as they can until their time runs out. then it tells them how many
   items they listed. it inherits everything from Activity. */
public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;

        /* these are the prompts we can show the user. */
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        /* get the list from the user and remember how many they said. */
        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    /* pick one random prompt from the list. */
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    /* let the user type items until their time runs out, and give back the list. */
    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        return items;
    }
}
