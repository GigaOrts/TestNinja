using NUnit.Framework;
using TestNinja.Fundamentals;
namespace TestNinja.UnitTest;

[TestFixture]
public class StackTests
{
    private Fundamentals.Stack<object> _stack;

    [SetUp]
    public void SetUp()
    {
        _stack = new();
    }

    [Test]
    public void Push_ArgumentIsNull_ThrowsArgNullException()
    {
        Assert.That(() => _stack.Push(null), 
            Throws.ArgumentNullException);
    }

    [Test]
    public void Push_ValidArg_AddObjectToStack()
    {
        _stack.Push("a");

        Assert.That(_stack.Count,Is.EqualTo(1));
    }

    [Test]
    public void Count_EmptyStack_ReturnZero()
    {
        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void Count_ElementAdded_ReturnOne()
    {
        _stack.Push("a");
        Assert.That(_stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        Assert.That(() => _stack.Pop(),
            Throws.InvalidOperationException);
    }

    [Test]
    public void Pop_StackWithFewObjects_ReturnObjectOnTop()
    {
        _stack.Push("a");
        _stack.Push("b");
        _stack.Push("c");

        var result = _stack.Pop();

        Assert.That(result, Is.EqualTo("c"));
    }

    [Test]
    public void Pop_StackWithFewObjects_RemoveObjectOnTop()
    {
        _stack.Push("a");
        _stack.Push("b");
        _stack.Push("c");

        _stack.Pop();

        Assert.That(_stack.Count, Is.EqualTo(2));
    }

    [Test]
    public void Peek_EmptyStack_ThrowsInvalidOperationException()
    {
        Assert.That(() => _stack.Peek(),
            Throws.InvalidOperationException);
    }

    [Test]
    public void Peek_StackWithObjects_ReturnObjectOnTop()
    {
        _stack.Push(2);

        var result = _stack.Peek();

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Peek_StackWithObjects_DoesNotRemoveObjectOnTop()
    {
        _stack.Push(2);

        _stack.Peek();

        Assert.That(_stack.Count, Is.EqualTo(1));
    }
}