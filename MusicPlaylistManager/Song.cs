using System;

namespace MusicPlaylistManager
{
    public class Song
    {
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Album { get; set; } = "";
        public string Genre { get; set; } = "";
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;

        public Song() { }

        public Song(string title, string artist, string album, string genre, TimeSpan duration) 
        {
            Title = title;
            Artist = artist;
            Album = album;
            Duration = duration;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} ({Duration:hh\\:mm\\:ss}) [{Genre}]";
        }
         
        public string ToCsv()
        { 
            return $"{Title}, {Artist}, {Album}, {Duration}, {Genre}";
        }
    }
}
