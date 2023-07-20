@user
Feature: User Feature 02
	Update user

Scenario: Update user
	Given Get update user payload "UpdateUser.json"
	Given Send request to update username
	Then Check firstname is updated
	Then Check lastname is updated

Scenario: Update user 2
	Given Get update user payload "UpdateUser.json"
	Given Send request to update username
	Then Check firstname is updated
	And Check lastname is updated	 
