using System;
public class StartUp
{
    public static void Main(string[] args)
    {
        var studentSystem = new StudentSystem();

        while (true)
        {
            studentSystem.ParseCommand();
        }
    }
}
