using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double GetTotalPower()
    {
        double ttlMonumentsPercentage = this.monuments.Sum(m => m.GetAffinity());
        double ttlBendersPower = this.benders.Sum(b => b.GetPower());

        return ttlBendersPower + ttlBendersPower / 100 * ttlMonumentsPercentage;
    }

    public void AddBender(Bender bender) => this.benders.Add(bender);

    public void AddMonument(Monument monument) => this.monuments.Add(monument);

    

    public bool HasMonuments()
    {
        if (this.monuments.Count == 0)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (this.benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in benders)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }
        if (this.monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var mon in monuments)
            {
                sb.AppendLine($"###{mon.ToString()}");
            }
        }

        return sb.ToString().Trim();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}
