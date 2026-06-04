using System;
using System.Threading;

/* the breathing activity walks the user through breathing in and out
   slowly until their time runs out. it inherits everything from Activity. */
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        /* figure out when we should stop based on the duration the user gave. */
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        /* keep alternating breathe in / breathe out until time is up. */
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...  ");
            ShowBreathBar(4, true);
            Console.WriteLine();

            /* check the time again so we don't go way over the duration. */
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");
            ShowBreathBar(6, false);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    /* CREATIVITY: this is my own breathing animation. instead of just a plain
       countdown, a bar of stars grows bigger while you breathe in and shrinks
       smaller while you breathe out, so it feels more like real breathing. */
    private void ShowBreathBar(int seconds, bool growing)
    {
        for (int i = 1; i <= seconds; i++)
        {
            /* when breathing in the bar gets longer, when breathing out it gets shorter. */
            int size = i;
            if (!growing)
            {
                size = seconds - i + 1;
            }

            string bar = new string('*', size);
            Console.Write(bar);
            Thread.Sleep(1000);

            /* erase the whole bar so we can redraw the next size in the same spot. */
            for (int j = 0; j < size; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
