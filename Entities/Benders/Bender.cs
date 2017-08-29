using System;
using System.Collections.Generic;

public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public abstract double GetPower();

    public int Power { get { return this.power; } }

    public override string ToString()
    {
        string bendType = this.GetType().Name;
        int typeEnd = bendType.IndexOf("Bender");
        bendType = bendType.Insert(typeEnd, " ");

        return $"{bendType}: {this.name}, Power: {this.Power}";
    }

}
