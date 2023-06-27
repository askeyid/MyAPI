Feature: CreateUser
	Create a new user

@regression
Scenario: Create a new user
	Given User with first name "Alex"
	And User with second name "Malyhon"
	And User with "random02@gmail.com" email
	When Send request to create user
	Then Validate 200 code
