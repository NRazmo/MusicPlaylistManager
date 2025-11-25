using System;
using System.IO;
using System.Globalization;


class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();
        if (!File.Exists("songs_dataset.csv"))
        {
            Console.WriteLine("Error: songs_dataset.csv not found");
            return;
        }

        string[] lines = File.ReadAllLines("songs_dataset.csv");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            if (fields.Length < 6)
                continue;
            string title = fields[1];
            string artist = fields[2];
            string album = fields[3];

            TimeSpan duration;
            if (!TimeSpan.TryParseExact(fields[4], "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out duration))
            {
                duration = TimeSpan.Zero;
            }

            string genre = fields[5];
            Song song = new Song
            {
                Title = title,
                Artist = artist,
                Album = album,
                Duration = duration,
                Genre = genre
            };
            playlist.AddSong(song);
        }
        Console.WriteLine("Songs loaded successfully!");
        playlist.PrintAll();
    }
}

