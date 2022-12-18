// namespace FinAuxTool.Core.Model;

/*
 * Currently not using Calendar years.
 * Just leaving it in for now as an example for a different type of year that would inherit from the abstract class year.
 *
 * Here my ideas about how it would be potentially set up in the future:
 *
 * The CalYear inherits from abstract year and from the iPeriod. Fine.
 * It has the existing Quarter as a child, which in turn gets the CalYear as a second parent.
 * Logically, the FinYear drives the CalYear creation, as well as setting, kind of like a mini orchestrator, the parent/child relationship between the two.
 * It does so AFTER the Quarters have been created in a separate routine. 
 */


// public class CalYear : Year, IPeriod
// {
//     public short PerVal { get; }
//     public string Label { get; }
//     public DateOnly BegDate { get; }
//     public DateOnly EndDate { get; }
//
//     public CalYear(short aYear) : base(aYear)
//     {
//     }
// }