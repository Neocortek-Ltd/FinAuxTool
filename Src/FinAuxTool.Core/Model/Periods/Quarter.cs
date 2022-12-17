using System.Globalization;

namespace FinAuxTool.Core.Model;

public class Quarter : IPeriod
{
    private const byte MonthsInQuarter = 3;
    public short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    internal CalYear CalYear { get; }
    public FinYear FinYear { get; set; }
    public Month[] Months { get; }

    internal Quarter(CalYear aCalYear, short aQuarter)
    {
        PerVal = aQuarter;
        Label = aCalYear.PerVal.ToString() + "-Q" + aQuarter.ToString();
        CalYear = aCalYear;

        var begMonth = 1 + (PerVal -1) * 3;
        var endMonth = begMonth + 2;
        BegDate = new DateOnly(CalYear.PerVal, begMonth,  1);
        EndDate = new DateOnly(CalYear.PerVal, endMonth, DateTime.DaysInMonth(CalYear.PerVal, endMonth));

        var firstMonthOfQuarter = 1 + (PerVal - 1) * MonthsInQuarter;

        Months = Enumerable.Range(0, MonthsInQuarter)
            .Select(i => new Month(this, (short)(firstMonthOfQuarter + i)))
            .ToArray();
    }
}    
