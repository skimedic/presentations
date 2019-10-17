# Using async methods in SpecFlow step definitions

## Background

SpecFlow supports using async methods as step definitions since version 2.2.
Features requiring asynchronous execution can now be written in a more C#-ish style.

```csharp
[Given("(.*)")]
public async Task GivenStep()
{
    await GetSomeTask();
}
```

Instead of writing your own state machine for awaiting tasks, SpecFlow has implemented this feature for you.

## Async-Await example

This example shows how to implement a step definition which calls the
[``HttpClient.GetAsync``](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getasync?view=netstandard-2.0#System_Net_Http_HttpClient_GetAsync_System_String_) method.
