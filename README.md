# AutoServiceSystem
Auto Service System in C# - Final exam - Practice build 

You are assigned to create a **Auto Service System**. The application should hold **clients**, **vehicles**, **repairs** which are the main app entities. The functionality of the app should support creating, listing, editing and deleting. The application should persist the data into a database. Data validation and error handling is a plus but is not mandatory.

## Overview
Your application should be built on each one of the following technologies:

### C#
* **ASP.NET** framework (ASP.NET MVC + Entity Framework)
* **Razor** view engine
* **Entity Framework** ORM framework
* **ADO.NET** Data Model 
* **MSSQL Server** database

## Data Model
The `Client` entity holds 8 properties:
* `id` - int identifier 
* `FullName` - nonempty nvarchar(50)
* `Gender` - nonempty nvarchar(10)
* `Phone` - nonempty nvarchar(50)
* `Address` - nonempty nvarchar(150)
* `Email` - nonempty nvarchar(255)
* `NationalCardNumber` - nonempty nvarchar(50)
* `PIN` - nonempty nchar(10)

The `Vehicle` entity holds 7 properties:
* `id` - int identifier 
* `VIN` - nonempty nvarchar(50)
* `RegistrationPlate` - nonempty nvarchar(50)
* `Make` - nonempty nvarchar(50)
* `Model` - nonempty nvarchar(50)
* `Color` - nonempty nvarchar(50)
* `ClientId` - int reference key

The `Repair` entity holds 5 properties:
* `id` - int identifier 
* `CreatedDate` - nonempty datetime
* `Description` - nonempty nvarchar(50)
* `Price` - nonempty decimal(19,4)
* `VehicleId` - int reference key

## User Interface
This is the user interface should consists of the following pages (under the designated routes):

### Index Page
Route: `client/index` (GET)

List of all clients.
 
### Create Page
Route: `client/create` (GET and POST)

`GET` shows a form to create a client. `POST` saves the form data into the database as new record.
 
### Delete Page
Route: `client/delete/{id}` (GET and POST)

`GET` shows a form to delete a certain client. `POST` confirms deleting a client and removes the record from the database.

### Edit Page
Route: `client/edit/{id}` (GET and POST)

`GET` shows a form to edit a certain client. `POST` confirms editing a client and modifies the record in the database.

Route: `vehicle/index` (GET)

List of all vehicles.
 
### Create Page
Route: `vehicle/create` (GET and POST)

`GET` shows a form to create a vehicle. `POST` saves the form data into the database as new record.
 
### Delete Page
Route: `vehicle/delete/{id}` (GET and POST)

`GET` shows a form to delete a certain vehicle. `POST` confirms deleting a vehicle and removes the record from the database.

### Edit Page
Route: `vehicle/edit/{id}` (GET and POST)

`GET` shows a form to edit a certain vehicle. `POST` confirms editing a vehicle and modifies the record in the database.

Route: `repair/index` (GET)

List of all repairs.
 
### Create Page
Route: `repair/create` (GET and POST)

`GET` shows a form to create a repair. `POST` saves the form data into the database as new record.
 
### Delete Page
Route: `repair/delete/{id}` (GET and POST)

`GET` shows a form to delete a certain repair. `POST` confirms deleting a repair and removes the record from the database.

### Edit Page
Route: `repair/edit/{id}` (GET and POST)

`GET` shows a form to edit a certain repair. `POST` confirms editing a repair and modifies the record in the database.

## Setup
Before you start working, make sure you download all the dependencies (packages) required for each technology and set up the databases! Below are instructions on how to do this:

### C# and ASP.NET MVC
The C# project will automatically resolve its **NuGet** dependencies (described in `packages.config`) using the NuGet package restore when the project is built.

