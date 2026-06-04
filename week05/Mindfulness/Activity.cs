using System;
using System.Collections.Generic;
using System.Threading;

/* this is the base class that all of the activities share.
   it holds the things every activity has (a name, a description, and a duration)
   and the behaviors every activity needs (the starting message, the ending
   message, and the pause animations). */
public class Activity
{
    /* these are protected instead of private so the child classes
       (BreathingActivity, ListingActivity, etc.) can use them directly. */
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    /* every activity starts the same way: show the name and description,
       ask how many seconds they want, then pause to let them get ready. */
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    /* every activity ends the same way: tell them good job, then remind
       them what they did and for how long. */
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
        Console.WriteLine();
    }

    /* this is the spinner animation. it keeps spinning until the number
       of seconds we asked for has passed. */
    public void ShowSpinner(int seconds)
    {
        /* these are the characters that make the spinner look like it turns. */
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b"); /* erase the character we just drew */

            i++;
            /* go back to the start of the list when we reach the end */
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    /* this counts down on the screen, one number per second. */
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); /* erase the number so the next one shows in the same spot */
        }
    }
}
