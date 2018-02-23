using System;public class InvalidSongLengthException : InvalidSongException
{
    private const string DefaultMessage = "Invalid song length.";

    public InvalidSongLengthException()
    :base(DefaultMessage)
    {
    }

    public InvalidSongLengthException(string message)
        : base(message)
    {
    }
}
