@user
Feature: User Feature 01
	Update user

Scenario: Update user
	Given Get update user payload "UpdateUser.json"
	Given Send request to update username
	Then Check firstname is updated
	And Check lastname is updated
	And Fail the test

@DataSource:SayHello.csv @ignore
Scenario Outline: Update user 2
	Given Get update user payload "UpdateUser.json"
	Given Send request to update username
	Then Check firstname is updated
	And Check lastname is updated
Examples:
	| name  | phrase |
	| Oleg  | HELLO  |
	| Maria | HEY    |

@myTag
Scenario: User enter creds scenario
	When User enter creds
		| FirstName  | Height In Inches | Bank Account Balance | # Header row (property names)
		| John Galt  | 73               | 1234.56              | # Data row (property values)
		| John Smith | 72               | 1234.57              | # Data row (property values)
	
@myScenario
Scenario: when do sth
	When Peter does something