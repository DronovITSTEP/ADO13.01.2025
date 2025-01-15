
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/15/2025 18:48:26
-- Generated from EDMX file: C:\Users\stud308\source\repos\ADO13.01.2025\ADO13.01.2025\SpamModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Spam];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SectionSet'
CREATE TABLE [dbo].[SectionSet] (
    [SectionId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PromoProductSet'
CREATE TABLE [dbo].[PromoProductSet] (
    [PromoProductId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [SectionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerId] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [SectionId] in table 'SectionSet'
ALTER TABLE [dbo].[SectionSet]
ADD CONSTRAINT [PK_SectionSet]
    PRIMARY KEY CLUSTERED ([SectionId] ASC);
GO

-- Creating primary key on [PromoProductId] in table 'PromoProductSet'
ALTER TABLE [dbo].[PromoProductSet]
ADD CONSTRAINT [PK_PromoProductSet]
    PRIMARY KEY CLUSTERED ([PromoProductId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SectionId] in table 'PromoProductSet'
ALTER TABLE [dbo].[PromoProductSet]
ADD CONSTRAINT [FK_SectionPromoProduct]
    FOREIGN KEY ([SectionId])
    REFERENCES [dbo].[SectionSet]
        ([SectionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionPromoProduct'
CREATE INDEX [IX_FK_SectionPromoProduct]
ON [dbo].[PromoProductSet]
    ([SectionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------