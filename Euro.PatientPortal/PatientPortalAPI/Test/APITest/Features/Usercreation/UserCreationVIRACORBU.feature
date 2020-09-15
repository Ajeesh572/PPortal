Feature: UserCreationVIRACORBU
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: 1 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 2 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 3 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 4 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 5 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 6 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 7 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 8 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 9 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	Scenario Outline: 10 Create Users and set Password Report first VIRACOR bu

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu      | email                                           | reportname                                   | numOfReports |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| VIRACOR | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |