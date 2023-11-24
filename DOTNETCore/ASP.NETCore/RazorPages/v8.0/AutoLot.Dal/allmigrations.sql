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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    IF SCHEMA_ID(N'Logging') IS NULL EXEC(N'CREATE SCHEMA [Logging];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Customers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [FullName] AS [LastName] + ', ' + [FirstName],
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Drivers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [FullName] AS [LastName] + ', ' + [FirstName],
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Makes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Makes] PRIMARY KEY ([Id]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[MakesAudit]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [Logging].[SeriLogs] (
        [Id] int NOT NULL IDENTITY,
        [Message] nvarchar(max) NULL,
        [MessageTemplate] nvarchar(max) NULL,
        [Level] nvarchar(128) NULL,
        [TimeStamp] datetime2 NOT NULL DEFAULT (GetDate()),
        [Exception] nvarchar(max) NULL,
        [Properties] Xml NULL,
        [LogEvent] nvarchar(max) NULL,
        [SourceContext] nvarchar(max) NULL,
        [RequestPath] nvarchar(max) NULL,
        [ActionName] nvarchar(max) NULL,
        [ApplicationName] nvarchar(max) NULL,
        [MachineName] nvarchar(max) NULL,
        [FilePath] nvarchar(max) NULL,
        [MemberName] nvarchar(max) NULL,
        [LineNumber] int NOT NULL,
        CONSTRAINT [PK_SeriLogs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[CreditRisks] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [FullName] AS [LastName] + ', ' + [FirstName],
        [CustomerId] int NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_CreditRisks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CreditRisks_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Inventory] (
        [Id] int NOT NULL IDENTITY,
        [Color] nvarchar(50) NOT NULL,
        [Price] decimal(18,2) NULL,
        [IsDrivable] bit NOT NULL DEFAULT CAST(1 AS bit),
        [DateBuilt] datetime2 NULL DEFAULT (getdate()),
        [Display] AS [PetName] + ' (' + [Color] + ')' PERSISTED,
        [PetName] nvarchar(50) NOT NULL,
        [MakeId] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Inventory_Makes_MakeId] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Makes] ([Id]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[InventoryAudit]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[InventoryToDrivers] (
        [Id] int NOT NULL IDENTITY,
        [DriverId] int NOT NULL,
        [InventoryId] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_InventoryToDrivers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_InventoryDriver_Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_InventoryDriver_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[InventoryToDriversAudit]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Orders] (
        [Id] int NOT NULL IDENTITY,
        [CarId] int NOT NULL,
        [CustomerId] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Inventory] ([Id]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[OrdersAudit]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE TABLE [dbo].[Radios] (
        [Id] int NOT NULL IDENTITY,
        [HasTweeters] bit NOT NULL,
        [HasSubWoofers] bit NOT NULL,
        [RadioId] nvarchar(50) NOT NULL,
        [InventoryId] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Radios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Radios_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id]) ON DELETE CASCADE,
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[RadiosAudit]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE INDEX [IX_CreditRisks_CustomerId] ON [dbo].[CreditRisks] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE INDEX [IX_Inventory_MakeId] ON [dbo].[Inventory] ([MakeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE INDEX [IX_InventoryToDrivers_DriverId] ON [dbo].[InventoryToDrivers] ([DriverId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_InventoryToDrivers_InventoryId_DriverId] ON [dbo].[InventoryToDrivers] ([InventoryId], [DriverId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE INDEX [IX_Orders_CarId] ON [dbo].[Orders] ([CarId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Orders_CustomerId_CarId] ON [dbo].[Orders] ([CustomerId], [CarId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Radios_CarId] ON [dbo].[Radios] ([InventoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181122_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220919181122_Initial', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181634_CustomSql')
BEGIN
    exec (N' 
                    CREATE VIEW [dbo].[CustomerOrderView]
                    AS
                    SELECT c.FirstName, c.LastName, i.Color, i.PetName, 
                        i.DateBuilt, i.IsDrivable, i.Price, i.Display, m.Name AS Make
                    FROM dbo.Orders o
                    INNER JOIN dbo.Customers c ON c.Id = o.CustomerId
                    INNER JOIN dbo.Inventory i ON i.Id = o.CarId
                    INNER JOIN dbo.Makes m ON m.Id = i.MakeId')
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181634_CustomSql')
BEGIN
    exec (N' 
                    CREATE PROCEDURE [dbo].[GetPetName]
                        @carID int,
                        @petName nvarchar(50) output
                    AS
                        SELECT @petName = PetName from dbo.Inventory where Id = @carID')
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181634_CustomSql')
BEGIN
    exec (N'
                    CREATE FUNCTION [dbo].[udtf_GetCarsForMake] ( @makeId int )
                    RETURNS TABLE 
                    AS
                    RETURN 
                    (
                        SELECT Id, IsDrivable, DateBuilt, Color, PetName, MakeId, TimeStamp, Display, Price
                        FROM Inventory WHERE MakeId = @makeId
                    )')
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181634_CustomSql')
BEGIN
    exec (N'
                    CREATE FUNCTION [dbo].[udf_CountOfMakes] ( @makeid int )
                    RETURNS int
                    AS
                    BEGIN
                        DECLARE @Result int
                        SELECT @Result = COUNT(makeid) FROM dbo.Inventory WHERE makeid = @makeid
                        RETURN @Result
                    END')
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919181634_CustomSql')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220919181634_CustomSql', N'6.0.9');
END;
GO

COMMIT;
GO

