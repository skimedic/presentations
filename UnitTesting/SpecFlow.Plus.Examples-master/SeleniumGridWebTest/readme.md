# Selenium Gird Web Test Example

This is a example how to use SpecFlow and SpecFlow+Runner to run Selenium Web Tests for different Browsers.  
The example is based on https://github.com/techtalk/SpecFlow.Plus.Examples/tree/master/SeleniumWebTest

## Prerequisites
To run this example, you need a running Selenium Grid. For installing, configuring and running have a look at: https://github.com/SeleniumHQ/selenium/wiki/Grid2

## Info about Parallelisation and Browser
### Chrome
everything works

### Firefox
should work

### Internet Explorer
On the same pc, you will not get any gain, because as it looks like, IEDriverServer does not handle multi instances of IE very performant. (Status from 2016-09-13)
Execute the tests on multiple nodes.



## Important parts

### app.config
In _configuration/appSettings/seleniumHub_ the used selenium grid is configured. 

### WebDriver.cs
This driver provides you access to the appropriate Selenium WebDriver. It uses the _configuration/appSettings/browser_ value for this.
As we are using Selenium Grid, a RemoteWebDriver with appropriate DesiredCapabilities is needed. This driver is configures with the _configuration/appSettings/seleniumHub_ Uri for the grid.
To get access to the Selenium Web Driver, use the _Current_ property on it. Use [Context Injection](http://www.specflow.org/documentation/Context-Injection/) to get the instance.

