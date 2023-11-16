namespace AutoLot.Services.Utilities;
public interface ISimpleService
{
    string SayHello();
}

public class SimpleServiceOne : ISimpleService
{
    public string SayHello() => "Hello from One";
}
public class SimpleServiceTwo : ISimpleService
{
    public string SayHello() => "Hello from Two";
}
