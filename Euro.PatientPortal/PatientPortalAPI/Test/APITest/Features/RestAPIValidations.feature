Feature: RestAPIValidations
	As a valid patient portal user,
	I want to verify if all the API's are working fine

	Scenario Outline: 1 Verify AddPatientReportInfo api works fine Without Report
	#When user hits api "AddPatientReportInfo" without Report "<reportname>" for BU "<bu>" and email "<email>" and save respose code by key "resKey"
	#Then verify that resposnse code "resKey" is "ok"
	When Verify Gmail

	Examples: 
	  | bu  | email                                             | reportname                                  |
	  | NTD | @GenerateRandomEmailWithDomain('dispostable.com') | Ajeesh kv COVID-19 IgG Test Report -286.pdf |

	  Scenario Outline: 2 Verify AddPatientReportInfo api works fine With Report
	When user hits api "AddPatientReportInfo" with Report "<reportname>" for BU "<bu>" and email "<email>" and save respose code by key "resKey"
	Then verify that resposnse code "resKey" is "ok"

	Examples: 
	  | bu  | email                                             | reportname                                  |
	  | NTD | @GenerateRandomEmailWithDomain('dispostable.com') | Ajeesh kv COVID-19 IgG Test Report -286.pdf |