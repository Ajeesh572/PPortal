Feature: RegisterUsers 1
	Wanted to create/Register multiple users


#	Scenario Outline: 1 Create Users and set Password user first for NTD BU
#	Given I create a user "User" with email "<email>" , BU "<bu>" and note the "refId"
#	When User set password "Eurofins@2020" for the user "User" with referenceId "refId"
#	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
#	#And I add report "<reportname>" for the user "User" 
#	And I add "<numOfReports>" reports for user "User"
#
#	
#	
#	Examples: 
#	  | bu  | email                                           | numOfReports |
#	  | NTD | @GenerateRandomEmailWithDomain(dispostable.com) | 1            |
#	  | NTD | @GenerateRandomEmailWithDomain(dispostable.com) | 2            |
#	  


#	  Scenario Outline: 2 Create Users and set Password Report first
#
#	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
#	When I Create User "User" and note referenceId "refId"
#	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
#	And I add "<numOfReports>" reports for user "User"
#	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
#	
#
#	
#	Examples: 
#	| bu      | email                                           | reportname                                   | numOfReports |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| NTD     | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	
#
#
#	 
#
#	 Scenario Outline: 3 Create Users and set Password Report first VIRACOR bu
#
#	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
#	When I Create User "User" and note referenceId "refId"
#	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
#	And I add "<numOfReports>" reports for user "User"
#	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
#
#	Examples: 
#	| bu      | email                                           | reportname                                   | numOfReports |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
#	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 10           |