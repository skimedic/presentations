# Custom Deployment Steps Example

This Example demonstrates the usage of Custom Deployment Steps for setting up the testing environment.
The testing part is based on the [Windows App Driver Example](https://github.com/techtalk/SpecFlow.Plus.Examples/tree/master/WindowsAppDriver)
and utilizes Custom Deployment Steps to start/stop the Windows App Driver.

## Setup

In order for this project to work [WinAppDriver](https://github.com/Microsoft/WinAppDriver/releases) must be installed on the system and
the path to WinAppDriver.exe must bepassed as an argument to the Custom Deployment step in Default.srprofile.

## Related Documentation

Documentation for (Custom) Deployment Steps can be found [here](http://specflow.org/plus/documentation/SpecFlowPlus-Runner-Profiles/#DeploymentTransformation)

## Additional Notes
Because this project is designed to work on all language versions of Windows, the `Assert` statements use `String.Contains()` to test the result. This is to ensure that the tests will pass irrespective of the language used by the Windows calculator, as the strings tested by the `Assert` also contain words in this language.

The flipside of this is that the tests will pass under certain circumstances, even if the result is incorrect (e.g. a result of "**120**000" will be treated the same as a result of "120" for the first test (50+70=120), i.e. results both will make the test pass).
