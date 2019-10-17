# Filter Example
This example shows the usage of filter in combination with Profiles to run only selected tests and associate a specific
configuration with a set of tests.

### Examples
The two profiles Simple and Complex should show how to use profiles to run only a specific set of tests and add specific
configuration to them.

The Sprint profiles show how to use regular expressions to filter the tests to execute.

The NotStable profile shows how to use logical expressions in filter.

For a complete list of available filter options see https://specflow.org/plus/documentation/SpecFlowPlus-Runner-Profiles/#Filter

### Filter Rules
Additionally to adding filter globally like in this example, it is also possible to apply filter only for specific targets.
Globally defined Filter will take predence over filter defined only for specific targets.


Please refer to the SeleniumWebTest project for an example for using filter with targets.


### Command Line filter
It is also possible to set filter when executing from the command line by specifying the filter argument. 
This argument overrides the global filter that is set in the .srprofile file but filter in the target definitions
will still be applied. 