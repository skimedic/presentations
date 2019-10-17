# Deployment Transformation With Multiple Threads

This example shows how to set up a SpecFlow test project for parallel execution with SpecFlow+Runner using deployment transformations.

## Overview

The example project is a simple .NET 4.7.1 database application using Entity Framework Core.
It provides an in-memory database storing `Person` instances with unique first and last name.

The .NET 4.7.1 test project utilizes SpecFlow 2.2.1 and is set up for test execution using SpecFlow+Runner.

## Set up parallel execution

The parallel execution is configured in the `Default.srprofile` file.
In order to enable parallel execution you must set the `testThreadCount` attribute of the `<Execution>` element to the number of threads you want to run your tests on.

For more information on the `<Execution>` element and how to choose the best test thread amount, have a look at [http://specflow.org/plus/documentation/Execution/](http://specflow.org/plus/documentation/Execution/)

## Set up deployment transformations

The test project needs an own database for each test thread.
Otherwise, we would end up with race conditions and unpredictable behavior.

A deployment transformation consists of steps, which are equivalent to operations.
These steps are configured in the `Default.srprofile` file.

In this project, two deployment transformation steps are used.
At first, the app.config is copied to `DatabaseCode.Tests.dll.{TestThreadId}.config` by using the `RelocateConfigurationFile` transformation step.
Then the configuration file's app settings are modified by using a `ConfigFileTransformation` step.

For more information on deployment transformation steps, visit [http://specflow.org/plus/documentation/DeploymentTransformation/](http://specflow.org/plus/documentation/DeploymentTransformation/).