Feature: CheckUsersInfo


@CheckUsersInfo
Scenario: Check user's base info
	When  I set language
	And input correct email, password and click log in button
	When I get to user profile page
	Then user's name and surname equals TestUser

@CheckUsersInfo
Scenario: Check user's address info
	When  I set language
	And input correct email, password and click log in button
	When I get to user profile page
	And  click user's addres info item
	Then user country is TestCountry
	And user city is TestCity
	And user street is TestStreet
