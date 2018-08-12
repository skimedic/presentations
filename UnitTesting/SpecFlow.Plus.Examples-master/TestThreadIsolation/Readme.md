# Test Thread Isolation Example

This example demonstrates the difference between SharedAppDomain, AppDomain and 
Process Isolation. 

## Config

The three provided .runsetting files can be used to start the tests in each above
mentioned mode. In Visual Studio select "Test>Test Settings>Select Test Settings File"
to choose the run configuration for the tests.

## SharedAppDomain

In SharedAppDomain mode the tests runs in seperate threads in one AppDomain.
That means that static data is shared between them and there is no protection between these threads.
On the other hand it is the fastest execution mode as there is
no need to spawn seperate AppDomains or processes. Additionally [BeforeTestRun] and
[AfterTestRun] is only executed once.

## AppDomain (Default)
In AppDomain mode the tests runs every thread runs in a seperate AppDomain.
That means that static data is not shared and the threads are protected from each other.
There is however still the possibility of shared memory, for example when using a 
shared in-memory SQLite database. This mode runs slower than SharedAppDomain but
has the advantage of thread protection

## Process
In Process mode the tests run in seperate processes. That means that nothing is shared
between them and it offers the highest form of protection. On the other hand it is
also the slowest mode of execution.

## Further information
[SpecFlow Documentation: Parallel Execution](https://specflow.org/documentation/Parallel-Execution/)

[Profile Configuration](https://specflow.org/plus/documentation/SpecFlowPlus-Runner-Profiles/#Environment)
