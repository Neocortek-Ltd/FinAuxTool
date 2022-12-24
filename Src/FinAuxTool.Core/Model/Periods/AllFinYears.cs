namespace FinAuxTool.Core.Model;

public class AllFinYears
{
    public FinYearUK[] FinYears { get; }

    public AllFinYears(IEnumerable<int> finYearsArg)
    {
        FinYears = finYearsArg.Select(finYearArg => new FinYearUK(finYearArg)).ToArray();
    }
}