Feature: This test suite contains test scenarios for Profile Page skill feature

Scenario Outline:A.Adding  New skills 
Given User navigates to skills tab
When User adds a new skill record <skill> <level>
Then Mars portal should save the new skill record <skill> 

Examples: 

| skill          | level          |
| 'Swimming'     | 'Intermediate' |
| 'Dancing'      | 'Beginner'     |
| 'Music'        | 'Intermediate' |
| 'Programming'  | 'Expert'       |
| 'Diving     '  | 'Expert'       |
| 'Driving     ' | 'Intermediate' |


Scenario Outline:B.Cancel the Add skill input entries without saving data
Given User navigates to skills tab
When User enter the skill details <skill> <level>
Then Mars portal should be able to discard the entered details without saving the skill record <skill> 

Examples: 
| skill         |  level         |
| 'Gardening'   | 'Intermediate' |


Scenario Outline:C.Add a skill without entering the data in the required fields
Given User navigates to skills tab
When User adds a new skill without entering the data <skill> <level>
Then Mars portal should display an alert message and should not save the skill record

Examples: 

| skill       | level                   |
| 'Cooking'   | 'Choose Skill level'    |
| ''          | 'Beginner'              |
| ''          | 'Choose Skill level'    |


Scenario Outline:D.Add a new skill with invalid data
Given User navigates to skills tab
When User try to add a new skill with invalid input <skill> <level>
Then Mars portal should display an alert mesage and should not save the skill record <skill>

Examples: 
| skill                     | level       |
| '@1234abc#$%&*'           | 'Beginner'  |

Scenario:E.Adding an existing skill with different level
Given User navigates to skills tab
When User try to add an existing skill with different level <skill> <level> 
Then Mars portal should display an alert message and should not add the skill record

Examples: 
| skill     | level      |
| 'Dancing'| 'Beginner'  |


Scenario:F.Adding a duplicate skill
Given User navigates to skills tab
When User try to duplicate data <skill> <level> 
Then Mars portal should display  alert message and should not save the skill record

Examples: 
| skill     | level           |
| 'Music'   | 'Intermediate'  |



Scenario Outline:G.Update an existing skill
When User edit an existing skill record <oldskill> <oldlevel> <newskill> <newlevel>
Then Mars portal should save the updated skill record <newskill>


Examples: 
| oldskill         | oldlevel            | newskill     | newlevel           |
| 'Programming'    | 'Expert'            | 'Gaming'     | 'Beginner'         |
| 'Diving'         | 'Expert'            | 'Diving'     | 'Intermediate'     |
| 'Driving'        | 'Intermediate'      | 'Sports'     | 'Intermediate'     |
#| 'Dancing'        | 'Beginner'          | 'Dancing'    | 'Beginner'         |

Scenario Outline:H.Update the skill record without editing both values 
When USer try to update skill record without editing both values <skill> <level>
Then Mars portal should display an alert message 

Examples: 
| skill    | level          | 
| 'Music'  | 'Intermediate' | 


Scenario Outline:I.Cancel the edit skill input entries without saving data
Given User navigates to skills tab
When User edit the skill details <oldskill> <oldlevel> <newskill> <newlevel>
Then Mars portal should be able to discard the changes without saving the skill record <oldskill>

Examples: 
| oldskill | oldlevel       | newskill  | newlevel |
| 'Music'  | 'Intermediate' | 'Cooking' | 'Expert' |


Scenario Outline:J.Delete the skill record  
When User try to delete a skill record <skill> <level> 
Then Mars portal should displays the message <skill> 

Examples: 
| skill       | level               | 
|'Swimming'  | 'Intermediate'       | 




