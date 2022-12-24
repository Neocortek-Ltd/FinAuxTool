using System.Diagnostics;

namespace FinAuxTool.Core.Model;

public class Month
{
    public int MonthInCalYear { get; }
    public Period Period { get; }
    public Quarter Quarter { get; }

    internal Month(Quarter parentQuarter, int aMonth)
    {
        Trace.Assert(aMonth is >= 1 and <= 12);
        MonthInCalYear = aMonth;
        Quarter = parentQuarter;
        var y = Quarter.FinYearUk.StartYear;

        Period = new Period
        {
            Label =  $"{y.ToString()}-{aMonth:D2}",
            BegDate = new DateOnly(y, MonthInCalYear, 1),
            EndDate = new DateOnly(y, MonthInCalYear, DateTime.DaysInMonth(y, MonthInCalYear)),
        };
    }
}