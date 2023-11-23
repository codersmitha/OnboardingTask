Feature: This test suite contains test scenarios for Profile Page Language feature


Scenario:A.Delete an existing Language
When User deletes all the records
Then User should not be able to view the deleted language record


Scenario Outline:B.Add a New Language
When User adds a new language record <language> <level>
Then Mars portal should save the new language record <language>

Examples: 

| language     | level                  |
| 'Spanish'    | 'Basic'                |
| 'Arabic'     | 'Conversational'       |
| 'French'     | 'Fluent'               |
| 'Chinese'    | 'Native/Bilingual'     |


Scenario Outline:C.Update an existing Language
When User edits an existing language record <oldlanguage> <oldlevel> <newlanguage> <newlevel>
Then Mars portal should save the updated language record <newlanguage> <newlevel>


Examples: 
| oldlanguage | oldlevel            | newlanguage  | newlevel           |
| 'Spanish'    | 'Basic'            | 'Hindi'      | 'Conversational'   |
| 'Arabic'     | 'Conversational'   | 'Arabic'     | 'Fluent'           |
| 'French'     | 'Fluent'           | 'Malayalam'  | 'Fluent'           |
| 'Chinese'    | 'Native/Bilingual' | 'Chinese'    | 'Basic'            |

Scenario Outline:D.User can cancel the Edit data
When USer try to update data and discard the changes <oldlanguage> <newlanguage> 
Then Mars portal should not save the updates <oldlanguage> <newlanguage>

Examples:
| oldlanguage | newlanguage  | 
| 'Chinese'   | 'Marathi'    |


Scenario:E.Update the laguage record without editing both values 
When USer try to update language record without editing both values  'Arabic' 'Fluent'
#Then Mars portal should display an alert message 


Scenario:F.Adding an existing language with different level
When User try to add an existing language with different level 'Malayalam' 'Basic'
Then Mars portal should display an alert message and should not add the record



Scenario Outline:G.Add a language without entering the data in the required fields
When User adds a new language without entering the data <language> <level>
Then Mars portal should display an alert message and should not save the record

Examples: 

| language     | level                  |
| 'Kannada'   | 'Choose language level' |
| ''          | 'Basic'                 |
| ''          | 'Choose language level' |


Scenario Outline:H.Cancel the Add language input entries without saving data
When User enter the language details <language> <level>
Then Mars portal should be able to discard the entered details without saving the record <language> <level>

Examples: 
| language    | level   |
| 'Kannada'   | 'Basic' |


Scenario Outline:I.Add a new language with invalid data 
When User try to add a language with invalid data <language> <level>
Then Mars portal should display an alert mesage and should not save the record <language> <level>

Examples: 
| language    | level    |
| 'abc@123'   | 'Basic'  |




Scenario Outline:J.User not allowed to add more than four languages
#Given Mars portal should have four records
When User try to add a fifth record <language> <level>
Then Mars portal should not allow to add the fifth record

Examples: 
| language    | level    |
| 'German '   | 'Basic'  |






 







