This project demonstrates how you can create feature files in one language, but specify values using a different locale. In this case, the feature file is in English and the values are specified using the Austrian formatting convention. That means:

* A comma is used as the decimal separator
* Dates are specified in the DD.MM.YYYY format

The feature file contains the following values (Austrian format):
* `1050,1`: In words, this is "one thousand and fifty and one tenth", and  corresponds to 1050.1 when using a decimal point as the decimal separator.
* `22.12.2010`: The 22nd of December 2010.

The conversion is handled in `AustrianLocalizationTransformer.cs`.

The steps (`ConvertSteps.cs`) assert that the number is equal to "1050.1" (i.e. using the English format) and that the date is equal to the 22nd of December 2010.