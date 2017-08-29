using System;
using System.Collections.Generic;

public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.name = name;
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        string monType = this.GetType().Name;
        int typeEnd = monType.IndexOf("Monument");
        monType = monType.Insert(typeEnd, " ");

        return $"{monType}: {this.name}";
    }

}