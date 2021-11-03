# AutoServiceSystem 
Back end project concept for building up an internal Auto-repair system written on C#. 

## Introduction 
Project structure easy to understand with skills learned from certification program with non-profit purpose. 

## Technologies 
  - C#
  - Class library
  - ADO.NET Data Model
  - Entity Framework 6.4.4

## Scope of functionalities

#### AutoServiceSystem.DataAccessLayer
  - IRepository: CRUD Interface that is used to abstract objects operations.
  - Components that manages the Entity and its operations by implementing the interface.
  - Class Mapping 1.6 Part of the current database, support methods that convert database objects to business objects and reverse.
 
 
#### AutoServiceSystem.DatabaseEntity
  - Generated objects from database to entity framework objects.
  - Wired configuration to SQL Server.


#### AutoServiceSystem.BusinessObjects
  - Contains business entities that are mapped in the database table.
