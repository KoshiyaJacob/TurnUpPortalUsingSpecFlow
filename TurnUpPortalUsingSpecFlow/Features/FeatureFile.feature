Feature: Login to the TurnUp portal and Create Time and materials and try to edit and delete the created data.


@LoginAndCreate
Scenario Outline: A Create time and material

Given I navigate to TurnUp portal with valid credentials "Hari" "123123"
When I navigate to Time and Material Page
And Record in Time and material "<Code>" "<Description>" "<Price>" should be created
Then the record should be saved "<Code>"


Examples: 

| Code                | Description                            | Price   |

|  Koshi Jacob 123    | Automation Demo in Time and Materials  |  20     |


@Edit
Scenario Outline: B Edit the created data

Given I navigate to TurnUp portal with valid credentials
When I navigate to Time and Material Page
And I edit the record "<new_code>" "<new_description>" "<new_price>"
Then the record should be updated 

Examples: 
| new_code           | new_description             | new_price |

| Koshiya Jacob      | Edited Automation Code       | 40        |
| Koshiya Jacob 123  | New Time and Materials        |   50        |

@Delete
Scenario: C Delete the created Time and material data

Given I navigate to TurnUp portal with valid credentials
When I navigate to Time and Material Page

And I delete the record from the Time and Material sheet
Then the record should be deleted and receive the alert message


