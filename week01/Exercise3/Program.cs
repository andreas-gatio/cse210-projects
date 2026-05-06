using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        Console.WriteLine("What is the magic number? (1-100) ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        while (favoriteNumber != number)
        {
            if (favoriteNumber > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }

        Console.Write("What is the magic number? ");
        favoriteNumber = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("You guessed it!");
    }
}