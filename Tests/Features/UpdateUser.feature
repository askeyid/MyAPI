@user
Feature: UpdateUser
	Update a user

Scenario: Update a user
	Given Get update user payload "UpdateUser.json"
	Given Send request to update username
	Then Check firstname is updated
	And Check lastname is updated	 
