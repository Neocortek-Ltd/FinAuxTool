using System.Diagnostics;

namespace FinAuxTool.Core.Model;

public class FinYearUK
{
    private const int QuartersInYear = 4;

    public int StartYear { get; }
    public Period Period { get; }
    public  Quarter[] Quarters { get; }
 
    public FinYearUK(int aYear)
    {
        Trace.Assert(aYear is >= 2000 and <= 2100);
        StartYear = aYear;

        Period = new Period
        {
            Label = $"{StartYear}/{StartYear + 1}-fUK", // suffix "fUK" for Financial Year in UK

            BegDate = new DateOnly(StartYear, 4, 1),
            EndDate = new DateOnly(StartYear + 1, 3, 31),
        };
        
        Quarters = Enumerable.Range(1, QuartersInYear)
            .Select(i => new Quarter(this, MapCalQtoFinQ(i)))
            .ToArray();
    }

    private static int MapCalQtoFinQ(int aCalQ)
    {
        return aCalQ switch
        {
            1 => 2,
            2 => 3,
            3 => 4,
            4 => 1,
            _ => throw new ArgumentException("Calender Quarter needs to be between 1 and 4")
        };
    }
}