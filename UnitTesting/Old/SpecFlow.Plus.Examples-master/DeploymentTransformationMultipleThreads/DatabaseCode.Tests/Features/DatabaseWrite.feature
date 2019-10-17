Feature: Database Write
    As a system
    I want to modify the data inside my database
    in order to work properly

Background: 
    Given I have an empty database

Scenario Outline: Creating a person in an empty database
    Given I have an empty database
    When I insert a person '<FirstName>' '<LastName>' into the database
    And I save and commit the changes to the database
    Then the database should contain a person called '<FirstName>' '<LastName>'.

    Examples:
    | FirstName | LastName |
    | David     | Eiwen    |

Scenario Outline: Modifying a person's name in the database in a wrong way
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | Davdi     | Eiwne    |

    And I get the person '<OldFirstName>' '<OldLastName>' from the database
    When I change its first name to '<NewFirstName>'
    And I change its last name to '<NewLastName>'
    Then saving and committing should throw an exception.

    Examples:
    | OldFirstName | OldLastName | NewFirstName | NewLastName |
    | Davdi        | Eiwne       | David        | Eiwen       |

Scenario Outline: Modifying a person's name in the database correctly      
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | Davdi     | Eiwne    |

    And I get the person '<OldFirstName>' '<OldLastName>' from the database
    When I delete a person called '<OldFirstName>' '<OldLastName>'
    And I insert a person '<NewFirstName>' '<NewLastName>' into the database
    And I save and commit the changes to the database
    Then the database should contain a person called '<NewFirstName>' '<NewLastName>'.

    Examples:
    | OldFirstName | OldLastName | NewFirstName | NewLastName |
    | Davdi        | Eiwne       | David        | Eiwen       |

Scenario Outline: Deleting a person in the database
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | David     | Eiwen    |
    When I delete a person called '<FirstName>' '<LastName>'
    And I save and commit the changes to the database
    Then the database should not contain a person called '<FirstName>' '<LastName>'.

    Examples:
    | FirstName | LastName |
    | David     | Eiwen    |

Scenario: Clearing all persons from the database
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | David     | Eiwen    |
    When I remove all persons
    And I save and commit the changes to the database
    Then the database should not contain any person.