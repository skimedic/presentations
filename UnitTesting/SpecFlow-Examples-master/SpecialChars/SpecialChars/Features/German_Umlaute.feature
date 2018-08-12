Feature: German Umlaute


Scenario Outline: German Umlaute are working
	Then the special char '<char>' is working


Examples: 
	| char |
	| ä    |
	| ö    |
	| ü    |
	| Ä    |
	| Ö    |
	| Ü    |