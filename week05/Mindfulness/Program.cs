using System;
using System.Collections.Generic;

/* W05 Project: Mindfulness Program

   How I exceeded the core requirements (creativity):

   1. I added a fourth activity called the Gratitude Activity (see
      GratitudeActivity.cs). It has the user list things they are grateful
      for, and at the end it randomly picks one of their own answers and
      tells them to carry that thought with them for the day.

   2. I made a better breathing animation (see BreathingActivity.cs). Instead
      of a plain countdown, a bar of stars grows bigger as you breathe in and
      shrinks smaller as you breathe out, so it feels more like real breathing.

   3. I added a simple activity log in this menu. The program counts how many
      times you have done each activity this session and shows the totals next
      to the menu options, so you can see what you have already done. */

class Program
{
    static void Main(string[] args)
    {
        /* this keeps track of how many times each activity was done this session. */
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;
        int gratitudeCount = 0;

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"  1. Start Breathing Activity   (done {breathingCount} times)");
            Console.WriteLine($"  2. Start Reflecting Activity  (done {reflectingCount} times)");
            Console.WriteLine($"  3. Start Listing Activity     (done {listingCount} times)");
            Console.WriteLine($"  4. Start Gratitude Activity   (done {gratitudeCount} times)");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                GratitudeActivity gratitude = new GratitudeActivity();
                gratitude.Run();
                gratitudeCount++;
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye! Take care of yourself.");
            }
            else
            {
                Console.WriteLine("That was not a valid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
