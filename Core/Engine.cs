using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder builder;
    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "Quit")
        {
            var cmdArgs = command.Split().ToList();
            ExecuteCommand(cmdArgs);

        }
        Console.WriteLine(builder.GetWarsRecord());
    }

    public void ExecuteCommand(List<string> cmdArgs)
    {
        var cmd = cmdArgs[0];
        cmdArgs.Remove(cmd);
        switch (cmd)
        {
            case "Bender":
                builder.AssignBender(cmdArgs);
                break;
            case "Monument":
                builder.AssignMonument(cmdArgs);
                break;
            case "Status":
                Console.WriteLine(builder.GetStatus(cmdArgs[0]));
                break;
            case "War":
                builder.IssueWar(cmdArgs[0]);
                break;
        }
    }
}
 