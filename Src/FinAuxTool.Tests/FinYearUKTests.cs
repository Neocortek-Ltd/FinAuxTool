namespace FinAuxTool.Tests;
using FinAuxTool.Core.Model;

[TestClass]
public class FinYearUKTests
{
    [TestMethod]
    public void FinYearUKConstructorTestValidYear()
    {
        //Arrange
        Dictionary<int, int[]> expectedPeriods = new ()
        {
            {2, new int[]{4, 5, 6}},
            {3, new int[]{7, 8, 9}},
            {4, new int[]{10, 11, 12}},
            {1, new int[]{1, 2, 3}},
        };

        //Act
        FinYearUK finYearUK = new FinYearUK(2022);;
        Dictionary<int, int[]> actualPeriods = finYearUK.Quarters
            .ToDictionary(quarter => quarter.QuarterInCalYear, quarter => quarter.Months.Select(month => month.MonthInCalYear)
            .ToArray());

        // Assert that Quarters are correct
        CollectionAssert.AreEqual(expectedPeriods.Keys, actualPeriods.Keys);
        
        // Assert that Months in each Quarter are correct
        foreach (int quarter in actualPeriods.Keys)
        {
            CollectionAssert.AreEqual(expectedPeriods[quarter],actualPeriods[quarter]);
        }
    }
}

