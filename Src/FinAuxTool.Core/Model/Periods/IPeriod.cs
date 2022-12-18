namespace FinAuxTool.Core.Model;

internal interface IPeriod
{
    public short PerVal { get; } // Period Value
    public string Label { get; }
    public DateOnly BegDate { get; }
    public DateOnly EndDate { get; }
}