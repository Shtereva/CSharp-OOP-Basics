using System;public class InvalidSongNameException : InvalidSongException
{
    private const string DefaultMessage = "Song name should be between 3 and 30 symbols.";

    public InvalidSongNameException()
    :base(DefaultMessage)
    {
    }
}
