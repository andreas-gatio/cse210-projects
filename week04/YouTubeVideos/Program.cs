using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // make a list to hold all the videos
        List<Video> videos = new List<Video>();

        // video 1
        Video video1 = new Video("How to Bake Bread", "Home Baker", 612);
        video1.AddComment(new Comment("Anna", "I tried this and it turned out great!"));
        video1.AddComment(new Comment("Marcus", "What flour do you recommend?"));
        video1.AddComment(new Comment("Lena", "Looks delicious, thanks for sharing."));
        videos.Add(video1);

        // video 2
        Video video2 = new Video("Learn C# in 30 Minutes", "CodeCraft", 1825);
        video2.AddComment(new Comment("David", "Best tutorial I have watched."));
        video2.AddComment(new Comment("Priya", "Can you make one on LINQ next?"));
        video2.AddComment(new Comment("Sam", "Very clear and easy to follow."));
        video2.AddComment(new Comment("Riko", "This helped me pass my exam!"));
        videos.Add(video2);

        // video 3
        Video video3 = new Video("Top 10 Hiking Trails", "Wander North", 945);
        video3.AddComment(new Comment("Erik", "Adding these to my bucket list."));
        video3.AddComment(new Comment("Maria", "Beautiful video!"));
        video3.AddComment(new Comment("Tomas", "What camera do you use?"));
        videos.Add(video3);

        // video 4
        Video video4 = new Video("Beginner Yoga", "Calm Body", 1320);
        video4.AddComment(new Comment("Jana", "My back feels so much better, thank you."));
        video4.AddComment(new Comment("Oliver", "Great length for my morning routine."));
        video4.AddComment(new Comment("Sara", "Easy to follow along."));
        videos.Add(video4);

        // loop through every video and print its info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthSeconds()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
