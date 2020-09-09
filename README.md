# Eurofins Core Automation Framework

# Contains

* WebDriver
* Selenium
* TestRail 
* Utilities

---
### Introduction

This Project contains the main clases to interact with different services like:
Webdriver, PageObjects, TestRail, API's, etc.

---
### Publish Nuget to IDT Nuget server

To publish a new version of IDT.Core.Automation nuget it is necessary follow the next steps:

```sh
1. Build IDT.Core.Automation project
2. Modify the version of "IDT.Core.Automation.nuspec" with a text editor:
   i.e: <version>1.0.x</version> Change x by a new version
3. Open a Command Prompt and navigate to IDT.Core project
   i.e: cd X:\RepositoryFolder\qe-core-automation\IDT.Core.Automation\
   ("RepositoryFolder" is the place where the repository was downloaded.)
4. Introduce the following comands:
    nuget pack IDT.Core.Automation.csproj
    nuget push IDT.Core.Automation.1.0.x.nupkg -Source http://nuget.am.idtcorp.net/ E53F382B-5B74-442B-961A-223F53B8FFAE
```