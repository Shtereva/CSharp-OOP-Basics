﻿using System;
public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const string DefaultMessage = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException()
    :base(DefaultMessage)
    {
    }
}
