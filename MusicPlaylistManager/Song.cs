using System;

public class Song
{
    public string Title { get; set; } = "";
    public string Artist { get; set; } = "";
    public string Album { get; set; } = "";
    public string Genre { get; set; } = "";
    public TimeSpan Duration { get; set; } = TimeSpan.Zero;


    public override string ToString()
    {
        if (Duration.TotalHours >= 1)
            return $"{Title} - {Artist} ({Duration:hh\\:mm\\:ss}) [{Genre}]";
        else
            return $"{Title} - {Artist} ({Duration:mm\\:ss}) [{Genre}]";
    }
}

