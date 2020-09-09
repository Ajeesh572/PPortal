@echo off
SET FolderProyect=%1
SET consoleOptions="%FolderProyect%.dll"
set filedScenarioFile="failedScenario.txt"
SET environmentOption=%2
SET languageOption=%3
SET count=%4
SET varTestRailNUnitCommand=%5
set failedScenariosListFileName=TestResult
for /L %%i in (1,1,%count%) do (
NUnit.ConsoleRunner.3.7.0\tools\nunit3-console %consoleOptions%  --out=%failedScenariosListFileName%%%i.txt "--result=%failedScenariosListFileName%%%i.xml;format=nunit2"  --testlist=%filedScenarioFile% --params=environment=%environmentOption%;Language=%languageOption%%varTestRailNUnitCommand:"=%
echo %%i)

exit