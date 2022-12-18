namespace FinAuxTool.Core.Services;

using FinAuxTool.Core.Model;

public class TestUsingDi
{
    private readonly AllFinYears _allFinYears;
    
    public TestUsingDi(AllFinYears allFinYears)
    {
        _allFinYears = allFinYears ?? throw new ArgumentNullException();
    }

    public void DoSomething()
    {
        Console.WriteLine(_allFinYears.FinYears[0].StartYear.ToString());
    }
}