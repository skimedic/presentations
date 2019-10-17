Feature: ContactList
	

Scenario: Empty Database displays empty contact list
	Given the following contacts are stored:
		| Firstname | Lastname |

	When I look at the contact list
	Then I see following contacts:
		| Firstname | Lastname |
		
#######################################################################################################################

Scenario: Entries in the database are displayed
	Given the following contacts are stored:
		| Firstname | Lastname |
		| Javier    | Knutson  |

	When I look at the contact list
	Then I see following contacts:
		| Firstname | Lastname |
		| Javier    | Knutson  |

#######################################################################################################################

Scenario: Multiple Entries in the database are displayed
	Given the following contacts are stored:
		| Firstname | Lastname     |
		| Javier    | Knutson      |
		| Nydia     | Butler       |
		| Milo      | Van Oirschot |

	When I look at the contact list
	Then I see '3' contacts

#######################################################################################################################
