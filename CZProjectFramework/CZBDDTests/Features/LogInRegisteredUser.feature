Feature: SwitchStations
             1.Open “Connections and tickets”
             2.Insert dispatch station
             3.Insert station of arrival
             4.Click switch button
             5.Click Search button

@VadzimAniska
Scenario: SwitchStations
	Given Connections and tickets page
	And Insert dispatch station
	And Insert station of arrival
	And Click switch button
	When Click Search button
	Then Station of arrival and dispatch station are switched places
