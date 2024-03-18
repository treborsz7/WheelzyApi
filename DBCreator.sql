
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/14/2024 00:15:30
-- Generated from EDMX file: D:\NET\WheelzyApi\Wheelzy\WheelzyBn\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [wheelzy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Car_Buyers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Car_Buyers];
GO
IF OBJECT_ID(N'[dbo].[FK_Car_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Car_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Car_State]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Car_State];
GO
IF OBJECT_ID(N'[dbo].[FK_Offers_Buyers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offers] DROP CONSTRAINT [FK_Offers_Buyers];
GO
IF OBJECT_ID(N'[dbo].[FK_Offers_car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offers] DROP CONSTRAINT [FK_Offers_car];
GO
IF OBJECT_ID(N'[dbo].[FK_State_Chages_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[State_Chages] DROP CONSTRAINT [FK_State_Chages_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_State_Chages_State]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[State_Chages] DROP CONSTRAINT [FK_State_Chages_State];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Buyers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buyers];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Offers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offers];
GO
IF OBJECT_ID(N'[dbo].[State_Chages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[State_Chages];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Buyers'
CREATE TABLE [dbo].[Buyers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nchar(20)  NULL,
    [Amount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Make] nchar(20)  NOT NULL,
    [Model] nchar(20)  NOT NULL,
    [Sub_model] nchar(20)  NULL,
    [Buyer_id] bigint  NULL,
    [Zip_code] nchar(20)  NOT NULL,
    [Customer_id] bigint  NOT NULL,
    [State_id] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nchar(30)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Offers'
CREATE TABLE [dbo].[Offers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Buyer_id] bigint  NOT NULL,
    [Car_id] bigint  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Acepted] bit  NOT NULL
);
GO

-- Creating table 'State_Chages'
CREATE TABLE [dbo].[State_Chages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Car_id] bigint  NOT NULL,
    [State_id] int  NOT NULL,
    [User] nvarchar(20)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nchar(30)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Username] nchar(20)  NOT NULL,
    [Password] nchar(20)  NOT NULL,
    [Permisions] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Buyers'
ALTER TABLE [dbo].[Buyers]
ADD CONSTRAINT [PK_Buyers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offers'
ALTER TABLE [dbo].[Offers]
ADD CONSTRAINT [PK_Offers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'State_Chages'
ALTER TABLE [dbo].[State_Chages]
ADD CONSTRAINT [PK_State_Chages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [Username], [Password] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id], [Username], [Password] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Buyer_id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Car_Buyers]
    FOREIGN KEY ([Buyer_id])
    REFERENCES [dbo].[Buyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_Buyers'
CREATE INDEX [IX_FK_Car_Buyers]
ON [dbo].[Cars]
    ([Buyer_id]);
GO

-- Creating foreign key on [Buyer_id] in table 'Offers'
ALTER TABLE [dbo].[Offers]
ADD CONSTRAINT [FK_Offers_Buyers]
    FOREIGN KEY ([Buyer_id])
    REFERENCES [dbo].[Buyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Offers_Buyers'
CREATE INDEX [IX_FK_Offers_Buyers]
ON [dbo].[Offers]
    ([Buyer_id]);
GO

-- Creating foreign key on [Customer_id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Car_Customer]
    FOREIGN KEY ([Customer_id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_Customer'
CREATE INDEX [IX_FK_Car_Customer]
ON [dbo].[Cars]
    ([Customer_id]);
GO

-- Creating foreign key on [State_id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Car_State]
    FOREIGN KEY ([State_id])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_State'
CREATE INDEX [IX_FK_Car_State]
ON [dbo].[Cars]
    ([State_id]);
GO

-- Creating foreign key on [Car_id] in table 'Offers'
ALTER TABLE [dbo].[Offers]
ADD CONSTRAINT [FK_Offers_car]
    FOREIGN KEY ([Car_id])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Offers_car'
CREATE INDEX [IX_FK_Offers_car]
ON [dbo].[Offers]
    ([Car_id]);
GO

-- Creating foreign key on [Car_id] in table 'State_Chages'
ALTER TABLE [dbo].[State_Chages]
ADD CONSTRAINT [FK_State_Chages_Car]
    FOREIGN KEY ([Car_id])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_State_Chages_Car'
CREATE INDEX [IX_FK_State_Chages_Car]
ON [dbo].[State_Chages]
    ([Car_id]);
GO

-- Creating foreign key on [State_id] in table 'State_Chages'
ALTER TABLE [dbo].[State_Chages]
ADD CONSTRAINT [FK_State_Chages_State]
    FOREIGN KEY ([State_id])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_State_Chages_State'
CREATE INDEX [IX_FK_State_Chages_State]
ON [dbo].[State_Chages]
    ([State_id]);
GO



INSERT INTO [dbo].[States]
           ([Description])
     VALUES
           ('Pending Acceptance'),('Accepted'),('Bought'),('Picked Up'),('Rejected')
GO

INSERT INTO [dbo].[Users]
           ([Username],
           [Password],
           [Permisions])
     VALUES
           ('Admin','Admin','read_todo,create_todo,edit_todo')
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------