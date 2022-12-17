namespace FinAuxToolTests;
using FinAuxTool.Core.Model;

[TestClass]
public class FinYearUKtest
{
    [TestMethod]
    public void FinYearUKconstructorTestvalidYear()
    {
        //Arrange
        FinYearUK finYearUK;

        //Act
        finYearUK = new FinYearUK(2022);
        var actualPeriods = finYearUK.Quarters
            .ToDictionary(quarter => quarter.PerVal, quarter => quarter.Months.Select(month => month.PerVal)
            .ToArray());

        // var actualPeriods = finYearUK.Quarters
        //     .Select(quarter => quarter.PerVal).ToArray();
        //
        // Assert
         var expectedPeriods = new Dictionary<short, short[]>()
         {
             {2, new short[]{4, 5, 6}},
             {3, new short[]{7, 8, 9}},
             {4, new short[]{10, 11, 12}},
             {1, new short[]{1, 2, 3}},
         };

        // var expectedPeriods = new short[] { 2, 3, 4, 1 };

        CollectionAssert.AreEqual(expectedPeriods.ToList(), actualPeriods.ToList());
    }
}

