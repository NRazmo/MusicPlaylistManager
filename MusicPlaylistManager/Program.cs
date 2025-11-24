using System;

class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();
        playlist.AddSong(new Song { Title = "Song 1", Artist = "Artist1", Album="Album1", Duration = TimeSpan.FromMinutes(3), Genre = "Pop" });
        playlist.AddSong(new Song { Title = "Song2", Artist = "Artist2", Album = "Album2", Duration = TimeSpan.FromMinutes(4), Genre = "Rock" });
            playlist.PrintAll();
    }
}
