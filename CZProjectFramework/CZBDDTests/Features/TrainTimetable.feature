Feature: TrainTimetable
	I want to be sure that timetable 
	of a particular train is displayed
	

@trainTimetable
Scenario: Verify train timetable visibility
	Given I am on the home page
	When I click on Train page link
	And I enter train name into the Search input
	And I click Search button
	Then train timetable should be found and be the same as on the search page

@trainTimetable
Scenario: Verifying train departure and destination stations
	Given I am on train details page 
	When I scroll to bottom of the page and click calendar popup link
	Then destination and departure stations in the opened popup should be equals as on the train details page

@trainTimetable
Scenario: Searching train timetable with invalid train name input
	Given I am on train page searching a train
	When I type train name which is not exist
	Then error message should be displayed

@trainTimetable
Scenario: Checking train timetable details
	Given I am on train details page looking for the train details
	When the page is loaded 
	Then train map should be shown
	And at least one service should be displayed
	And at least one accessibility station should be displayed
	And at least one line should be displayed

@trainTimetable
Scenario: Saving timetable in PDF
	Given I am on Train page trying to save my timetable in PDF
	When I click Save as PDF button
	Then PDF timetable should be downloaded