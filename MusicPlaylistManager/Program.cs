using System;
using System.IO;
using System.Globalization;

namespace MusicPlaylistManager
{

    class Program
    {
        static void Main(string[] args)
        {
            Playlist playlist = new Playlist();
            LoadSongsFromCSV(playlist);
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Music Playlist Manager ---\n");
                Console.WriteLine("1. View All Songs");
                Console.WriteLine("2. Add Song");
                Console.WriteLine("3. Remove Song");
                Console.WriteLine("4. Search Songs");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        playlist.PrintAll();
                        break;

                    case "2":
                        AddSongMenu(playlist);
                        break;

                    case "3":
                        RemoveSongMenu(playlist);
                        break;

                    case "4":
                        SearchMenu(playlist);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting Program...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Try Again.");
                        break;
                }
            }
        }

        static void LoadSongsFromCSV(Playlist playlist)
        {
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
                string genre = fields[5];

                TimeSpan duration;
                if (!TimeSpan.TryParseExact(fields[4], "hh\\:mm\\:ss",
                    CultureInfo.InvariantCulture, out duration))
                {
                    duration = TimeSpan.Zero;
                }

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
        }

        static void AddSongMenu(Playlist playlist)
        {
            Console.Write("Enter song title: ");
            string title = Console.ReadLine();

            Console.Write("Enter artist: ");
            string artist = Console.ReadLine();

            Console.Write("Enter album: ");
            string album = Console.ReadLine();

            Console.Write("Enter duration (hh:mm:ss): ");
            TimeSpan duration;

            if (!TimeSpan.TryParseExact(Console.ReadLine(), "hh\\:mm\\:ss",
                CultureInfo.InvariantCulture, out duration))
            {
                Console.WriteLine("Invalid duration!");
                duration = TimeSpan.Zero;
            }

            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();

            Song newSong = new Song
            {
                Title = title,
                Artist = artist,
                Album = album,
                Duration = duration,
                Genre = genre
            };

            playlist.AddSong(newSong);
            Console.WriteLine("Song added successfully!");
        }

        static void RemoveSongMenu(Playlist playlist)
        {
            playlist.PrintAll();
            Console.Write("Enter song index to remove: ");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                playlist.RemoveSong(index);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void SearchMenu(Playlist playlist)
        {
            Console.Write("Enter search keyword: ");
            string keyword = Console.ReadLine();

            playlist.Search(keyword);
        }
    }
}