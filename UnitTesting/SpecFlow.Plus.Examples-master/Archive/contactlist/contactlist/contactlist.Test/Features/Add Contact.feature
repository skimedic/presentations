Feature: Add Contact

Scenario: Add contact with firstname 
	Given I enter following data in the "New Contact" dialog:
		| Firstname |
		| Javier    |

	When I save the contact

	Then the following contacts are stored:
		| Firstname | 
		| Javier    | 

############################################################################################################


Scenario: Add contact with lastname 
	Given I enter following data in the "New Contact" dialog:
		| Lastname |
		| Knutson  |

	When I save the contact

	Then the following contacts are stored:
		| Lastname |
		| Knutson  |