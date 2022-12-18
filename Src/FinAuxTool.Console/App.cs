namespace FinAuxTool.Console;

using Core.Model;
using System;

public class App
{
    private readonly IFinYearUK _finYearUK;

    public App(IFinYearUK aFinYearUK)
    {
        _finYearUK = aFinYearUK;
    }

    public void Run()
    {
        Console.WriteLine(_finYearUK.PerVal.ToString());
    }
}