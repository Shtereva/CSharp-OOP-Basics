using System;
using System.Collections.Generic;
using System.Linq;

public static class InputParser
{
    public static void ParseSoldierInfo(string[] args, List<ISoldier> soldiers)
    {
        string soldierType = args[0];
        string[] soldierInfo = args.Skip(1).ToArray();
        switch (soldierType)
        {
            case "Private":
                CheckSoldierInfo(s => soldierInfo.Length != s, 4);

                var @private = new Private(soldierInfo[0], soldierInfo[1], soldierInfo[2], double.Parse(soldierInfo[3]));

                soldiers.Add(@private);
                break;
            case "LeutenantGeneral":
                CheckSoldierInfo(s => soldierInfo.Length < s, 4);

                var leutenantGeneral = new LeutenantGeneral(soldierInfo[0], soldierInfo[1], soldierInfo[2], double.Parse(soldierInfo[3]));
                AddPrivates(leutenantGeneral, soldierInfo.Skip(4), soldiers);

                soldiers.Add(leutenantGeneral);
                break;
            case "Engineer":
                CheckSoldierInfo(s => soldierInfo.Length < s, 5);

                List<IRepair> repairs = AddRepairs(soldierInfo.Skip(5).ToList());
                var engineer = new Engineer(soldierInfo[0], soldierInfo[1], soldierInfo[2], double.Parse(soldierInfo[3])
                    , CheckCorps(soldierInfo), repairs);

                soldiers.Add(engineer);
                break;
            case "Commando":
                CheckSoldierInfo(s => soldierInfo.Length < s, 5);

                List<IMission> missions = AddMissions(soldierInfo.Skip(5).ToList());
                var commando = new Commando(soldierInfo[0], soldierInfo[1], soldierInfo[2], double.Parse(soldierInfo[3])
                    , CheckCorps(soldierInfo), missions);

                soldiers.Add(commando);
                break;
            case "Spy":
                CheckSoldierInfo(s => soldierInfo.Length != s, 4);

                var spy = new Spy(soldierInfo[0], soldierInfo[1], soldierInfo[2], int.Parse(soldierInfo[3]));

                soldiers.Add(spy);
                break;
            default:
                break;
        }
    }

    private static List<IMission> AddMissions(List<string> collection)
    {
        var missions = new List<IMission>();

        for (int i = 0; i < collection.Count; i += 2)
        {
            StateType state;

            if (!Enum.TryParse<StateType>(collection[i + 1], out state))
            {
                continue;
            }

            missions.Add(new Mission(collection[i], state));
        }

        return missions;
    }

    private static CorpsType CheckCorps(string[] soldierInfo)
    {
        CorpsType corps;
        if (!Enum.TryParse<CorpsType>(soldierInfo[4], out corps))
        {
            throw new ArgumentException();
        }

        return corps;
    }

    private static List<IRepair> AddRepairs(List<string> collection)
    {
        var repairs = new List<IRepair>();

        for (int i = 0; i < collection.Count - 1; i += 2)
        {
            repairs.Add(new Repair(collection[i], int.Parse(collection[i + 1])));
        }

        return repairs;
    }

    private static void AddPrivates(LeutenantGeneral leutenantGeneral, IEnumerable<string> privates, List<ISoldier> soldiers)
    {
        foreach (var @privateId in privates)
        {
            var @private = soldiers.Find(s => s.Id == privateId);
            leutenantGeneral.AddPrivate(@private as Private);
        }
    }


    private static void CheckSoldierInfo(Predicate<int> predicate, int len)
    {
        if (predicate.Invoke(len))
        {
            throw new ArgumentException();
        }
    }
}
