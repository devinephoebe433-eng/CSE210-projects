using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Video
    {
        public string _title;
        public string _author;
        public int _length;
        public List<Comment> _comments;

        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
            _comments = new List<Comment>();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_length} seconds");
            Console.WriteLine($"Number of Comments: {_comments.Count}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in _comments)
            {
                Console.WriteLine($"  - {comment._author}: {comment._text}");
            }
        }
    }
}
