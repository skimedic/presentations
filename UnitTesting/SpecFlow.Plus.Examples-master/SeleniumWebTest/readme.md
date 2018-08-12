# Selenium Web Test Example

This is a example how to use SpecFlow and SpecFlow+Runner to run Selenium Web Tests for different Browsers.  
The example is based on https://github.com/baseclass/Contrib.SpecFlow.Selenium.NUnit

This example also takes a screenshot after each step and embeds the screnshot in the final report. Refer to the documentation [here] (http://www.specflow.org/plus/documentation/Tutorial:-Customising-Reports) for an explanation of how the screenshot's path is passed to the report.

## Important parts

### app.config
In _configuration/appSettings/browser_ the used browser is configured. This value is changed by a ConfigFileTransformation in the **Default.srProfile**

### Default.srProfile

#### Targets
3 Targets (one for every browser) are defined here. They have a filter on the tag _Browser_\_**__{BrowserName}__**, so only scenarios with the tag is executed in this target.

#### DeploymentSteps
2 deployment steps are configured
1. IISExpress - this starts a IIS Express instance, so you do not have to check it manually that it is running
2. ConfigFileTransformation - this sets the _configuration/appSettings/browser_ to the target name


### WebDriver.cs
This driver provides you access to the appropriate Selenium WebDriver. It uses the _configuration/appSettings/browser_ value for this.
To get access to the Selenium Web Driver, use the _Current_ property on it. Use [Context Injection](http://www.specflow.org/documentation/Context-Injection/) to get the instance.


### CalculatorFeature.feature
Here are the scenarios defined.  
To get a scenario executed for a browser, add a tag _Browser_\_**__{BrowserName}__** to the scenario/scenario outline/feature.  

**Example for a scenario for all 3 browsers:**
```
@Browser_Chrome
@Browser_IE
@Browser_Firefox
Scenario: Basepage is Calculator
	Given I navigated to /
	Then browser title is Calculator
```
