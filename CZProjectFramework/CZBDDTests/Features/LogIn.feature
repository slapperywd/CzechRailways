Feature: LogIn


@Log in
Scenario: Log in registered user
	When I set language
	And input correct email, password and click log in button
	Then link log out and logged user's name are displayed

@Log in
Scenario: Log in unregistered user
	When I set language
	And input incorrect email, password and click log in button
	Then user is not logged in, error message is displayed
