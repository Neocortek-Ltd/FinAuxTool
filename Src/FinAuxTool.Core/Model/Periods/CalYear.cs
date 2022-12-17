namespace FinAuxTool.Core.Model;

public class CalYear : Year, IPeriod
{
    public short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }

    public CalYear(short aYear) : base(aYear)
    {
    }
}