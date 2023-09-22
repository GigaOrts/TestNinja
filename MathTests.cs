using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTest;

[TestFixture]
public class MathTests
{
    private Math _math;

    [SetUp]
    public void SetUp()
    {
        _math = new Math();
    }

    [Test]
    // [Ignore("Because I can!")]
    public void Add_WhenCalled_ReturnSumOfTwoNumbers()
    {
        var result = _math.Add(1, 2);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    [TestCase(2, 1, 2)]
    [TestCase(1, 2, 2)]
    [TestCase(2, 2, 2)]
    public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
    {
        var result = _math.Max(a, b);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
    {
        var result = _math.GetOddNumbers(5);

        // Most General
        Assert.That(result, Is.Not.Null);

        // Specific
        //Assert.That(result.Count(), Is.EqualTo(3));

        //// Another General
        //Assert.That(result, Does.Contain(1));
        //Assert.That(result, Does.Contain(3));
        //Assert.That(result, Does.Contain(5));

        // Equivalent to Does.Contains(..) 3x
        Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));

        // Some useful assert methods
        //Assert.That(result, Is.Ordered);
        //Assert.That(result, Is.Unique);
    }
}