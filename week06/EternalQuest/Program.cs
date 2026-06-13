using System;

// Exceeding requirements:
// 1. I added a leveling system. Every 1000 points the user gains a level, and each
//    level has a title (Beginner, Disciple, Hero, Legend) that shows on the main screen.
// 2. I added a fourth goal type called a Negative Goal. This is for bad habits. Every
//    time you record it you LOSE points instead of gaining them, which helps you try to
//    stop doing them.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
