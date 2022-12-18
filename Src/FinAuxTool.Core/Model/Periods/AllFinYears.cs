namespace FinAuxTool.Core.Model;

public class AllFinYears : IAllFinYears
{
    public FinYearUK[] FinYears { get; }

    public AllFinYears(short[] finYearsArg)
    {
        FinYears = finYearsArg.Select(finYearArg => new FinYearUK(finYearArg)).ToArray();
    }
}