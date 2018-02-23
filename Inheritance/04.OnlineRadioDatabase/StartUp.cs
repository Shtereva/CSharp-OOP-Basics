using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var songs = new List<Song>();

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine();

            try
            {
                var tokens = input.Split(';');

                string artistName = tokens[0];
                string songName = tokens[1];

                var lenght = tokens[2].Split(':');

                try
                {
                    int minutes = int.Parse(lenght[0]);
                    int seconds = int.Parse(lenght[1]);

                    var song = new Song(artistName, songName, minutes, seconds);

                    songs.Add(song);
                }
                catch (FormatException e)
                {
                    throw new InvalidSongLengthException();
                }
                Console.WriteLine("Song added.");
            }

            catch (InvalidSongException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        PrintSongsInfo(songs);

    }

    private static void PrintSongsInfo(List<Song> songs)
    {
        Console.WriteLine($"Songs added: {songs.Count}");
        double totalSeconds = 0;
        foreach (var item in songs)
        {
            totalSeconds += (item.Minutes * 60) + item.Seconds;
        }

        var result = TimeSpan.FromSeconds(totalSeconds);
        Console.WriteLine($"Playlist length: {result.Hours}h {result.Minutes}m {result.Seconds}s");
    }
}
