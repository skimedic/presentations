namespace CreationPatternsTests.Singleton;

[Collection("CreationalPatternsTests")]
public class SingletonTests
{
    [Fact]
    public void ShouldCreateJustOneInstance()
    {
        MySingletonClass first = MySingletonClass.Instance;
        MySingletonClass second = MySingletonClass.Instance;
        Assert.Same(first, second);
        first.SomeValue++;
        Assert.Equal(first.SomeValue, second.SomeValue);
        second.SomeValue++;
        Assert.Equal(first.SomeValue, second.SomeValue);
    }
    [Fact]
    public void ShouldCreateJustOneInstanceOfSimpleSingleton()
    {
        MySimplerSingletonClass first = MySimplerSingletonClass.Instance;
        MySimplerSingletonClass second = MySimplerSingletonClass.Instance;
        Assert.Same(first, second);
        first.SomeValue++;
        Assert.Equal(first.SomeValue, second.SomeValue);
        second.SomeValue++;
        Assert.Equal(first.SomeValue, second.SomeValue);
    }
}