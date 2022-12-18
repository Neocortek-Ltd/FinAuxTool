namespace FinAuxTool.Console;

using Core.Model;
using Core.Services;
using System;

public class App
{
    private readonly IAllFinYears _allFinYears;

    public App(IAllFinYears aAllFinYears)
    {
        _allFinYears = aAllFinYears;
    }

    internal void Run()
    {
        Console.WriteLine(_allFinYears.FinYears[0].PerVal.ToString());
        Console.WriteLine(_allFinYears.FinYears[1].PerVal.ToString());

        TestUsingDi t = new TestUsingDi(_allFinYears);
        t.DoSomething();
    }
}

