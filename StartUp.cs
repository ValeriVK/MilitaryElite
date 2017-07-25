using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static IList<IPrivate> army;
    public static void Main()
    {

        string input;
        army = new List<IPrivate>();
        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();
            switch (args[0])
            {
                case "Private":
                    army.Add(new Private(int.Parse(args[1]), args[2], args[3], double.Parse(args[4])));
                    break;

                case "Spy":
                    army.Add(new Spy(int.Parse(args[1]), args[2], args[3], 0, int.Parse(args[4])));
                    break;

                case "LeutenantGeneral":
                    var privates = ExtractPrivates(args.Skip(5).ToList());
                    army.Add(new LeutenantGeneral(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), privates));
                    break;

                case "Commando":
                    if (args[5] != "Airforces" && args[5] != "Marines")
                    {
                        break;
                    }
                    var missions = ExtractMissions(args.Skip(6).ToList());
                    army.Add(new Commando(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), args[5], missions));
                    break;

                case "Engineer":
                    if (args[5] != "Airforces" && args[5] != "Marines")
                    {
                        break;
                    }
                    var repairs = ExtractRepairs(args.Skip(6).ToList());
                    army.Add(new Engineer(int.Parse(args[1]), args[2], args[3], double.Parse(args[4]), args[5], repairs));
                    break;
            }
        }

        foreach (var soldier in army)
        {
            Console.WriteLine(soldier);
        }
    }

    private static IList<IPrivate> ExtractPrivates(IList<string> ids)
    {
        var list = new List<IPrivate>();

        foreach (var id in ids)
        {
            list.Add(army.First(s => s.Id == int.Parse(id)));
        }

        return list;
    }

    private static IList<IMission> ExtractMissions(IList<string> missions)
    {
        var list = new List<IMission>();

        for (int i = 0; i < missions.Count - 1; i += 2)
        {
            if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
            {
                continue;
            }
            list.Add(new Mission(missions[i], missions[i + 1]));
        }

        return list;
    }

    private static IList<IRepair> ExtractRepairs(IList<string> repairs)
    {
        var list = new List<IRepair>();

        for (int i = 0; i < repairs.Count - 1; i += 2)
        {
            list.Add(new Repair(repairs[i], int.Parse(repairs[i + 1])));
        }

        return list;
    }
}