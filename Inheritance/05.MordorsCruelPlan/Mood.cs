using System;

public class Mood : MoodFactory
{
    public override string GetMood(int points)
    {
        string nl = Environment.NewLine;
        
        if (points < -5)
        {
            return $"{points}{nl}Angry";
        }

        if (points >= -5 && points <= 0)
        {
            return $"{points}{nl}Sad";
        }

        if (points >= 1 && points <= 15)
        {
            return $"{points}{nl}Happy";
        }
        return $"{points}{nl}JavaScript";
    }
}
