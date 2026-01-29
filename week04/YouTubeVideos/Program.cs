using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Video 1
            Video v1 = new Video("C# Abstraction Tutorial", "CodeMaster", 600);
            v1._comments.Add(new Comment("Alice", "This was so helpful!"));
            v1._comments.Add(new Comment("Bob", "I finally understand classes."));
            v1._comments.Add(new Comment("Charlie", "Great video, keep it up."));
            videos.Add(v1);

            // Video 2
            Video v2 = new Video("10 Minutes of Ocean Waves", "NatureRelax", 600);
            v2._comments.Add(new Comment("Dave", "So peaceful."));
            v2._comments.Add(new Comment("Eve", "I fell asleep in 2 minutes."));
            v2._comments.Add(new Comment("Frank", "The audio quality is amazing."));
            videos.Add(v2);

            // Video 3
            Video v3 = new Video("How to Bake Sourdough", "ChefJen", 1200);
            v3._comments.Add(new Comment("Grace", "My bread didn't rise :("));
            v3._comments.Add(new Comment("Heidi", "Best tutorial on the platform."));
            v3._comments.Add(new Comment("Ivan", "What brand of flour do you use?"));
            videos.Add(v3);

            // Display all videos
            foreach (Video video in videos)
            {
                video.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}