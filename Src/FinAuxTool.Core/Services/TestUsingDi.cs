namespace FinAuxTool.Core.Services;

using FinAuxTool.Core.Model;

public class TestUsingDi
{
    private readonly IAllFinYears _allFinYears;
    
    public TestUsingDi(IAllFinYears allFinYears)
    {
        _allFinYears = allFinYears ?? throw new ArgumentNullException();
    }

    public void DoSomething()
    {
        Console.WriteLine(_allFinYears.FinYears[0].PerVal.ToString());
    }
}