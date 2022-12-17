namespace FinAuxTool.Core.Model;

public class CalYear : Year, IPeriod
{
    private const byte QuartersInYear = 4;
    public new short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    public  Quarter[] Quarters { get; }

    public CalYear(short aYear) : base(aYear)
    {
        PerVal = base.PerVal;
        Label = aYear.ToString() + "c"; // suffix "c" for Calendar Year (vs. "f" for Financial Year). 
        
        BegDate = new DateOnly(aYear, 1, 1);
        EndDate = new DateOnly(aYear, 12, 31);

        Quarters = Enumerable.Range(1, QuartersInYear)
            .Select(i => new Quarter(this, (short)i)).ToArray();
    }
}