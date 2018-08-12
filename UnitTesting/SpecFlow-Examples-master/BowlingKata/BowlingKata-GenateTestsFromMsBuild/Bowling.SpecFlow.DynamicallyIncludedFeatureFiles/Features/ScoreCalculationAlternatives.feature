Feature: Score Calculation (alternative forms)
  As a player
  I want the system to calculate my total score
  So that I know my performance

  
Scenario: One single spare
  Given a new bowling game
  When I roll the following series:	3,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
  Then my total score should be 29
  
Scenario: All spares
  Given a new bowling game
  When I roll 10 times 1 and 9
  And I roll 1
  Then my total score should be 110

Scenario: Yet another beginners game
  Given a new bowling game
  When I roll
  | Pins	|
  |	2		|
  |	7		|
  |	1		|
  |	5		|
  |	1		|
  |	1		|
  |	1		|
  |	3		|
  |	1		|
  |	1		|
  |	1		|
  |	4		|
  |	1		|
  |	1		|
  |	1		|
  |	1		|
  |	8		|
  |	1		|
  |	1		|
  |	1		|
  Then my total score should be 43
  
Scenario Outline: Score calculation tables
  Given a new bowling game
  When I roll the following series:	<rolls>
  Then my total score should be <total score>

Examples: 
  | game             | rolls                                   | total score |
  | beginners game   | 2,7,3,4,1,1,5,1,1,1,1,1,1,1,1,1,1,1,5,1 | 40          |
  | one single spare | 2,8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 | 29          |
