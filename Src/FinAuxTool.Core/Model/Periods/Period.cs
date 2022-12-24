namespace FinAuxTool.Core.Model;

public record Period
{
    internal string Label { get; init; }
    internal DateOnly BegDate { get; init; }
    internal DateOnly EndDate { get; init; }
}