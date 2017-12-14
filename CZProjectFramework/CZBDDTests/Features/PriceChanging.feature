Feature: PriceChanging
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@PriceChanging
Scenario: Price change after adding new defoulte passenger
	When  I set language
	And  set directions
	And set day tomorrow
	And set time 12 00
	And get prices before adding
	When i add new defaulte passenger
	And get prices after adding
	Then pricess after adding nore 2x or 2xrestrict coefficient then prices before adding 
