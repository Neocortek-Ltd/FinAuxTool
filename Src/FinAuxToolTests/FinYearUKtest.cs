namespace FinAuxToolTests;
using FinAuxTool.Core.Model;

[TestClass]
public class FinYearUKtest
{
    [TestMethod]
    public void FinYearUKconstructorTestvalidYear()
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
            .ToDictionary(quarter => quarter.PerVal, quarter => quarter.Months.Select(month => month.PerVal)
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

