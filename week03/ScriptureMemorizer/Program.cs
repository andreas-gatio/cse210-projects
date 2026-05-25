using System;
using System.Collections.Generic;

// CREATIVITY: Instead of just one scripture, the program now has a list of several scriptures that is chosen at random each time it runs. Also, the program only chooses already visible words to hide, so it doesn't try to re-hide a word that is already hidden

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>();

        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"));

        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"));

        library.Add(new Scripture(
            new Reference("Joshua", 1, 9),
            "Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest"));

        Random random = new Random();
        int choice = random.Next(0, library.Count);
        Scripture scripture = library[choice];

        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                keepGoing = false;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Press the enter key to continue or type 'quit' to finish: ");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    keepGoing = false;
                }
                else
                {
                    scripture.HideRandomWords(3);
                }
            }
        }
    }
}
