using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest;

[TestFixture]
public class DateHelperTests
{
    [Test]
    public void FirstOfNextMonth_WhenMonthIs12_ReturnDateTimeYearPlus1()
    {
        var year = 2000;
        var date = new DateTime(year, 12, 1);

        var result = DateHelper.FirstOfNextMonth(date);

        Assert.That(result.Year, Is.EqualTo(year + 1));
        Assert.That(result.Month, Is.EqualTo(1));
        Assert.That(result.Day, Is.EqualTo(1));
    }

    [Test]
    public void FirstOfNextMonth_WhenMonthIsNot12_ReturnDateTimeWithMonthPlus1()
    {
        var month = 1;
        var year = 2000;
        var date = new DateTime(year, month, 1);

        var result = DateHelper.FirstOfNextMonth(date);

        Assert.That(result.Year, Is.EqualTo(year));
        Assert.That(result.Month, Is.EqualTo(month + 1));
        Assert.That(result.Day, Is.EqualTo(1));
    }
}