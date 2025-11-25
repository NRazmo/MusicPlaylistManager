using System;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public string Genre { get; set; }
    public TimeSpan Duration { get; set; }
    public Song Next { get; set; }


    public override string ToString() => $"{Title} - {Artist} ({Duration}) [{Genre}]";
}

