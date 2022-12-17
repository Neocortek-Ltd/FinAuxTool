namespace FinAuxTool.Core.Model;

public class FinYearUK : Year, IPeriod
{
    private const byte QuartersInYear = 4;
    public new short PerVal { get; }
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    public  Quarter[] Quarters { get; }

    public FinYearUK(short aYear) : base(aYear)
    {
        PerVal = base.PerVal;
        Label = aYear.ToString() + "/" + (aYear + 1).ToString() + "-fUK"; // suffix "fUK" for Financial Year in UK 
        
        BegDate = new DateOnly(aYear, 4, 1);
        EndDate = new DateOnly(aYear + 1, 3, 31);

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