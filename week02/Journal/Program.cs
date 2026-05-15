using System;

// === Creativity Feature: Weekly Reflection ===
// This program goes beyond the core requirements by adding a "Weekly Reflection" feature.
// When the user runs the program on a Monday, it automatically shows all journal entries
// from the past 7 days and prompts them to write a summary of their week. The summary is
// saved as its own entry with a "Weekly Reflection" prompt. The user can also access the
// reflection any time from the menu (option 6) to look back over their recent entries.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
        {
            Console.WriteLine();
            Console.WriteLine("It's Monday — time for your weekly reflection!");
            journal.WeeklyReflection();
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Weekly Reflection");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;

                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                case "6":
                    journal.WeeklyReflection();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
