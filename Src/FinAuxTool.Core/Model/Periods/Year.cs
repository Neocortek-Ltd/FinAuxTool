using System.Diagnostics;

namespace FinAuxTool.Core.Model;

public abstract class Year
{
    protected short PerVal { get; private set; }

    protected Year(short aYear)
    {
        SetPerVal(aYear);
    }

    private void SetPerVal(short aYear)
    {
        Trace.Assert(aYear is >= 1900 and <= 2100);
        PerVal = aYear;
    }
    
}