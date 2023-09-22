using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest;

[TestFixture]
public class FizzBuzzTests
{
    [Test]
    public void GetOutput_IsDivisibleBy3And5_ReturnFizzBuzz()
    {
        var result = FizzBuzz.GetOutput(15);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GetOutput_IsDivisibleBy3Only_ReturnFizz()
    {
        var result = FizzBuzz.GetOutput(3);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GetOutput_IsDivisibleBy5Only_ReturnBuzz()
    {
        var result = FizzBuzz.GetOutput(3);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GetOutput_IsNotDivisibleBy3Or5_ReturnSameValue()
    {
        var result = FizzBuzz.GetOutput(1);

        Assert.That(result, Is.EqualTo("1"));
    }
}