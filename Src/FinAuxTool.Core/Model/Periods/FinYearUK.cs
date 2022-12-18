using System.Diagnostics;

namespace FinAuxTool.Core.Model;

public class FinYearUK
{
    private const byte QuartersInYear = 4;

    public short StartYear { get; }
    public Period Period { get; }
    public  Quarter[] Quarters { get; }
 
    public FinYearUK(short aYear)
    {
        Trace.Assert(aYear is >= 2000 and <= 2100);
        StartYear = aYear;

        Period = new Period
        {
            Label = StartYear.ToString() + "/" + (StartYear + 1).ToString() + "-fUK", // suffix "fUK" for Financial Year in UK
            BegDate = new DateOnly(StartYear, 4, 1),
            EndDate = new DateOnly(StartYear + 1, 3, 31),
        };
        
        Quarters = Enumerable.Range(1, QuartersInYear)
            .Select(i => new Quarter(this, MapCalQtoFinQ(i)))
            .ToArray();
    }

    private static short MapCalQtoFinQ(int aCalQ)
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