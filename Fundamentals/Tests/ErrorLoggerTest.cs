using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest;

[TestFixture]
public class ErrorLoggerTest
{
    [Test]
    public void Log_WhenCalled_SetTheLastErrorProperty()
    {
        var logger = new ErrorLogger();

        logger.Log("a");

        Assert.That(logger.LastError, Is.EqualTo("a"));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Log_InvalidError_ThrowArgNullException(string error)
    {
        var logger = new ErrorLogger();

        // Wouldn't work, because method will throw an exception first
        // logger.Log("");

        Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        
        // Too long, but we can use it when we need some exception we don't have
        // Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Log_ValidError_RaiseErrorLoggedEvent()
    {
        var logger = new ErrorLogger();

        var id = Guid.Empty;

        // lambda is "event handler"
        logger.ErrorLogged += (sender, args) => { id = args; };

        logger.Log("a");

        Assert.That(id, Is.Not.EqualTo(Guid.Empty));
    }
}