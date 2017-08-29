using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warsHistory;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            { "Air", new Nation() },
            { "Fire", new Nation() },
            { "Earth", new Nation() },
            { "Water", new Nation() }
        };
        this.warsHistory = new List<string>();

    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        Bender curBender = this.GetBender(benderArgs);
        this.nations[type].AddBender(curBender);

    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        Monument curMonument = this.GetMonument(monumentArgs);
        this.nations[type].AddMonument(curMonument);
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation").AppendLine(nations[nationsType].ToString());

        return sb.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        double winningPoints = this.nations.Max(p => p.Value.GetTotalPower());

        foreach (var nat in this.nations.Values)
        {
            if (nat.GetTotalPower() != winningPoints)
            {
                nat.DeclareDefeat();
            }
        }

        warsHistory.Add(nationsType);
    }
    public string GetWarsRecord()
    {
        StringBuilder wars = new StringBuilder();
        for (int i = 0; i < warsHistory.Count; i++)
        {
            wars.AppendLine($"War {i + 1} issued by {warsHistory[i]}");
        }

        return wars.ToString().Trim();
    }

    //------------------------------------------------------------------------

    private Bender GetBender(List<string> bendArgs)
    {
        var type = bendArgs[0];
        var name = bendArgs[1];
        var power = int.Parse(bendArgs[2]);
        var secParam = double.Parse(bendArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secParam);
            case "Water":
                return new WaterBender(name, power, secParam);
            case "Fire":
                return new FireBender(name, power, secParam);
            case "Earth":
                return new EarthBender(name, power, secParam);
            default:
                throw new ArgumentException();
        }
    }

    private Monument GetMonument(List<string> monArgs)
    {
        var type = monArgs[0];
        var name = monArgs[1];
        var affinity = int.Parse(monArgs[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            default:
                throw new ArgumentException();
        }
    }
}
