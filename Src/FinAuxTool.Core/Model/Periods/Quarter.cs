using System.Globalization;

namespace FinAuxTool.Core.Model;

public class Quarter : IPeriod
{
    private const byte MonthsInQuarter = 3;
    public short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    public FinYearUK FinYearUk { get; }
    public CalYear CalYear { get; set; }
    public Month[] Months { get; }

    internal Quarter(FinYearUK aFinYearUk, short aQuarter)
    {
        PerVal = aQuarter;
        Label = aFinYearUk.PerVal.ToString() + "-Q" + aQuarter.ToString();
        FinYearUk = aFinYearUk;

        var begMonth = 1 + (PerVal -1) * 3;
        var endMonth = begMonth + 2;
        BegDate = new DateOnly(FinYearUk.PerVal, begMonth,  1);
        EndDate = new DateOnly(FinYearUk.PerVal, endMonth, DateTime.DaysInMonth(FinYearUk.PerVal, endMonth));

        var firstMonthOfQuarter = 1 + (PerVal - 1) * MonthsInQuarter;

        Months = Enumerable.Range(0, MonthsInQuarter)
            .Select(i => new Month(this, (short)(firstMonthOfQuarter + i)))
            .ToArray();
    }
}    
