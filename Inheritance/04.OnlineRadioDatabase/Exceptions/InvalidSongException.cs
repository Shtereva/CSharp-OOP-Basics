using System;

public class InvalidSongException : ArgumentException
{
    private const string DefaultMessage = "Invalid song.";

    public InvalidSongException()
        :base(DefaultMessage)
    {
    }

    public InvalidSongException(string message)
        : base(message)
    {
    }
}
