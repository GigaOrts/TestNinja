using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest;

[TestFixture]
public class PhoneNumberTests
{
    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Parse_IsNullOrWhiteSpace_ThrowArgException(string number)
    {
        Assert.That(() => PhoneNumber.Parse(number), Throws.ArgumentException);
    }

    [Test]
    public void Parse_LengthIsNotEqualsTo10_ThrowArgException()
    {
        Assert.That(() => PhoneNumber.Parse(new string('0', 9)), Throws.ArgumentException);
    }

    [Test]
    public void Parse_ValidArg_ReturnPhoneNumber3By3By4()
    {
        var number = "1234567890";
        PhoneNumber phoneNumber = PhoneNumber.Parse(number);

        Assert.That(phoneNumber.Area, Is.EqualTo(number.Substring(0, 3)));
        Assert.That(phoneNumber.Major, Is.EqualTo(number.Substring(3, 3)));
        Assert.That(phoneNumber.Minor, Is.EqualTo(number.Substring(6)));
    }
}