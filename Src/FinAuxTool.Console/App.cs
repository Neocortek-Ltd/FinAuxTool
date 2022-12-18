using FinAuxTool.Core.Model;
using FinAuxTool.Core.Services;

namespace FinAuxTool.Console;

using System;

public class App
{
    private readonly AllFinYears _allFinYears;
    private readonly TestUsingDi _testUsingDi;

    public App(AllFinYears aAllFinYears, TestUsingDi aTestUsingDi)
    {
        _allFinYears = aAllFinYears;
        _testUsingDi = aTestUsingDi;
    }

    internal void Run()
    {
        // This block is just test code for now! 
        Console.WriteLine(_allFinYears.FinYears[0].StartYear.ToString());
        Console.WriteLine(_allFinYears.FinYears[1].StartYear.ToString());
        _testUsingDi.DoSomething();
    }
}

