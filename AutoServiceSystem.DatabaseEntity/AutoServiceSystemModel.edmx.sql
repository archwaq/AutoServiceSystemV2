
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2022 13:43:11
-- Generated from EDMX file: C:\AutoServiceSystemV2\AutoServiceSystem.DatabaseEntity\AutoServiceSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoServiceSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Repair_Repair]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Repair] DROP CONSTRAINT [FK_Repair_Repair];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicle_Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK_Vehicle_Vehicle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Repair]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Repair];
GO
IF OBJECT_ID(N'[dbo].[Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicle];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(50)  NOT NULL,
    [Gender] nvarchar(10)  NOT NULL,
    [Phone] nvarchar(50)  NOT NULL,
    [Address] nvarchar(150)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [NationalCardNumber] nvarchar(50)  NOT NULL,
    [PIN] nchar(10)  NOT NULL
);
GO

-- Creating table 'Repairs'
CREATE TABLE [dbo].[Repairs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [CreeatedDate] datetime  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [VehicleId] int  NOT NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [VIN] nvarchar(50)  NOT NULL,
    [RegistrationPlate] nvarchar(50)  NOT NULL,
    [Make] nvarchar(50)  NOT NULL,
    [Model] nvarchar(50)  NOT NULL,
    [Color] nvarchar(50)  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Repairs'
ALTER TABLE [dbo].[Repairs]
ADD CONSTRAINT [PK_Repairs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_Vehicle_Vehicle]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehicle_Vehicle'
CREATE INDEX [IX_FK_Vehicle_Vehicle]
ON [dbo].[Vehicles]
    ([ClientId]);
GO

-- Creating foreign key on [VehicleId] in table 'Repairs'
ALTER TABLE [dbo].[Repairs]
ADD CONSTRAINT [FK_Repair_Repair]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Repair_Repair'
CREATE INDEX [IX_FK_Repair_Repair]
ON [dbo].[Repairs]
    ([VehicleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------