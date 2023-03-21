IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE TABLE [Dbo].[Customers] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [FirstName] nvarchar(50) NULL,
        [LastName] nvarchar(50) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE TABLE [dbo].[Makes] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [Name] nvarchar(50) NULL,
        CONSTRAINT [PK_Makes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE TABLE [Dbo].[Inventory] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [MakeId] int NOT NULL,
        [Color] nvarchar(50) NOT NULL,
        [PetName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Make_Inventory] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Makes] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE TABLE [Dbo].[Orders] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [CustomerId] int NOT NULL,
        [CarId] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY ([CarId]) REFERENCES [Dbo].[Inventory] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Dbo].[Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE INDEX [IX_Inventory_MakeId] ON [Dbo].[Inventory] ([MakeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE INDEX [IX_Orders_CarId] ON [Dbo].[Orders] ([CarId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    CREATE INDEX [IX_Orders_CustomerId] ON [Dbo].[Orders] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528014226_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528014226_Initial', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528023327_AddSproc')
BEGIN

    CREATE VIEW [dbo].[CustomerOrderView]
    AS
    SELECT dbo.Customers.FirstName, dbo.Customers.LastName, dbo.Inventory.Color, dbo.Inventory.PetName, dbo.Makes.Name AS Make
    FROM   dbo.Orders 
    INNER JOIN dbo.Customers ON dbo.Orders.CustomerId = dbo.Customers.Id 
    INNER JOIN dbo.Inventory ON dbo.Orders.CarId = dbo.Inventory.Id
    INNER JOIN dbo.Makes ON dbo.Makes.Id = dbo.Inventory.MakeId 
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528023327_AddSproc')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528023327_AddSproc', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528024602_AddCreditRisk')
BEGIN
    CREATE TABLE [Dbo].[CreditRisks] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [CustomerId] int NOT NULL,
        [FirstName] nvarchar(50) NULL,
        [LastName] nvarchar(50) NULL,
        CONSTRAINT [PK_CreditRisks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CreditRisks_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Dbo].[Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528024602_AddCreditRisk')
BEGIN
    CREATE INDEX [IX_CreditRisks_CustomerId] ON [Dbo].[CreditRisks] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528024602_AddCreditRisk')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_CreditRisks_FirstName_LastName] ON [Dbo].[CreditRisks] ([FirstName], [LastName]) WHERE [FirstName] IS NOT NULL AND [LastName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528024602_AddCreditRisk')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528024602_AddCreditRisk', N'7.0.0');
END;
GO

COMMIT;
GO

