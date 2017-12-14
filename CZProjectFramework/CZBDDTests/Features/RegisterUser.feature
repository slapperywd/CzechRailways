Feature: RegisterUser
			1. Click on button “Register”
			2. Fill “name”, “surname” and “e-mail” fields
			3. Click consent checkbox
			4. Click Register button
			5. Check entered mail
			6. Activate your account by doing what is said in received message from info@cd.cz
			7. Fill “New Password” and “Repeat Password”
			8. Click “Receive information about products and services” on your discretion
			9. Click confirmation button
			10. Click on triangle right to the name
			11. Click User profile button
			12. Click Account cancellation
			13. Click confirmation of cancellation
			14. Click Cancel button
			15. Fill Password field
			16. Click Save changes button

@Eugene
Scenario: RegisterNewUser
	Given Home Page
	And insert "name" into a field
	And insert "surname" into a field
	And insert "e-mail" into a field
	And click "consent checkbox"
	And click "Register button"
	And check entered mail
	And activate your account
	And insert "New Password" into a field
	And insert "password" into a field
	And click "radio button"
	And click "confirmation button"
	And click "triangle right to the name"
	And click "User profile button"
	And click "Account cancellation button"
	And click "confirmation of cancellation"
	And click "Cancel button"
	And insert "Password" into a field
	When click "Save changes button"
	Then the "Register button" appears on the right side