namespace FinAuxToolTests;
using FinAuxTool.Core.Model;

[TestClass]
public class FinYearUKTests
{
    [TestMethod]
    public void FinYearUKConstructorTestValidYear()
    {
        //Arrange
        var expectedPeriods = new Dictionary<short, short[]>()
        {
            {2, new short[]{4, 5, 6}},
            {3, new short[]{7, 8, 9}},
            {4, new short[]{10, 11, 12}},
            {1, new short[]{1, 2, 3}},
        };

        //Act
        FinYearUK finYearUK = new FinYearUK(2022);;
        var actualPeriods = finYearUK.Quarters
            .ToDictionary(quarter => quarter.QuarterInCalYear, quarter => quarter.Months.Select(month => month.MonthInCalYear)
            .ToArray());

        // Assert that Quarters are correct
        CollectionAssert.AreEqual(expectedPeriods.Keys, actualPeriods.Keys);
        
        // Assert that Months in each Quarter are correct
        foreach (var quarter in actualPeriods.Keys)
        {
            CollectionAssert.AreEqual(expectedPeriods[quarter],actualPeriods[quarter]);
        }
    }
}

