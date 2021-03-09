# Carsales Dev Exam

I used the following:
 - Visual Studio 2019 Community Edition
 - .Net Core 3.1 framework
 - Data persisted using MS SQL Server 2019
 - Implemented Clean Architecture using MediatR and CQRS design pattern.
 - For unit testing XUnit and Moq
 - For the frontend I use ASP.NET Core Web Application MVC
 - I use Postman to test my api endppoint

 The web api has the following endpints:
  - endpoint for listing the vehicle type properties (get: /api/VehicleTypeProperties/1)
  - endpoint for saving the created vehicle (post: /api/vehicle )

  For the test data I created a script(InsertTestDataScript.sql) to insert prerequisite data for the following:
  - vehicle types
  - vehicle properties
  - vehicle type properties


**BDD Scenarios**

**Scenario 1:** User successfully redirected to Create New Vehicle Page
GIVEN  User is on the homepage
WHEN they click Create Car from the dropdown 
THEN open Create New Vehicle page

**Scenario 2:** User successfully creates a car
GIVEN  User is on the create new vehicle page
WHEN they enters all required fields
THEN a New Vehicle record is created

**Scenario 3:** User does not input Make 
GIVEN  User is on the create new vehicle page
WHEN they enters all required fields except Make
THEN a message "The Make field is required" will appear

**Scenario 4:** User does not input Model
GIVEN  User is on the create new vehicle page
WHEN they enters all required fields except Model
THEN a message "The Model field is required" will appear

**Scenario 5:** User cancel creation of new vehicle
GIVEN  User is on the create new vehicle page
WHEN they enters all required fields but click Cancel button
THEN the system will redirect the user to the Home page
