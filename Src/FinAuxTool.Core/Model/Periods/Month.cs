namespace FinAuxTool.Core.Model;

public class Month : IPeriod
{
    public short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    public Quarter Quarter { get; }

    internal Month(Quarter parentQuarter, short aMonth)
    {
        Quarter = parentQuarter;
        var y = Quarter.CalYear.PerVal;
        
        PerVal = aMonth;
        Label = y.ToString() + "-" + $"{aMonth:D2}";
        
        BegDate = new DateOnly(y, PerVal, 1);
        EndDate = new DateOnly(y, PerVal, DateTime.DaysInMonth(y, PerVal));
    }
}