Feature: UserCreationNTDBU
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

		@api 
	 Scenario Outline: 1 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 2 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 3 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 4 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 5 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 6 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 7 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 8 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 9 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 10 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 11 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 12 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 13 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 14 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	@api
	Scenario Outline: 15 Create Users and set Password Report first

	Given I send report "<reportname>" for the user "User" with email "<email>" for Bu "<bu>"
	When I Create User "User" and note referenceId "refId"
	And I set password "Eurofins@2020" for created User "User" with referenceId "refId" 
	And I add "<numOfReports>" reports for user "User"
	And I added User creds username "User" password "Eurofins@2020" and number of reports added "<numOfReports>"
	
	Examples: 
	| bu  | email                                           | reportname                                   | numOfReports |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 1            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 2            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 3            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 4            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 5            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 6            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 7            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report -286.pdf  | 8            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 9            |
	| NTD | @GenerateRandomEmailWithDomain(dispostable.com) | Ajeesh kv COVID-19 IgG Test Report - 285.pdf | 10           |

	

	