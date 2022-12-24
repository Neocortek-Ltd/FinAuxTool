using System.Diagnostics;
using System.Globalization;

namespace FinAuxTool.Core.Model;

public class Quarter
{
    private const byte MonthsInQuarter = 3;
    
    public int QuarterInCalYear { get; }
    public Period Period { get; }
    public FinYearUK FinYearUk { get; }
    public Month[] Months { get; }

    internal Quarter(FinYearUK aFinYearUk, int aQuarter)
    {
        Trace.Assert(aQuarter is >= 1 and <= 4);
        QuarterInCalYear = aQuarter;
        FinYearUk = aFinYearUk;
        
        int begMonth = 1 + (QuarterInCalYear -1) * 3;
        int endMonth = begMonth + 2;
        Period = new Period
        {
            Label = $"{FinYearUk.StartYear.ToString()}-Q{aQuarter.ToString()}",
            BegDate = new DateOnly(FinYearUk.StartYear, begMonth,  1),
            EndDate = new DateOnly(FinYearUk.StartYear, endMonth, DateTime.DaysInMonth(FinYearUk.StartYear, endMonth)),
        };
        
        int firstMonthOfQuarter = 1 + (QuarterInCalYear - 1) * MonthsInQuarter;
        Months = Enumerable.Range(0, MonthsInQuarter)
            .Select(i => new Month(this, (firstMonthOfQuarter + i)))
            .ToArray();
    }
}    
