namespace FinAuxTool.Core.Model;

public interface IPeriod
{
    public short PerVal { get; } // Period Value
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
    
}