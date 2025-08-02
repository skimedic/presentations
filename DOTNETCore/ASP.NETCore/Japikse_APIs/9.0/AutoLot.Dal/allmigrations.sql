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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    IF SCHEMA_ID(N'Logging') IS NULL EXEC(N'CREATE SCHEMA [Logging];');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Drivers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [FullName] AS [LastName] + ', ' + [FirstName],
        [LastName] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Makes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Makes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
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
        [LineNumber] int NULL DEFAULT 0,
        CONSTRAINT [PK_SeriLogs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
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
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Inventory_Makes_MakeId] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Makes] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE TABLE [dbo].[InventoryToDrivers] (
        [Id] int NOT NULL IDENTITY,
        [DriverId] int NOT NULL,
        [InventoryId] int NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_InventoryToDrivers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_InventoryDriver_Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_InventoryDriver_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Radios] (
        [Id] int NOT NULL IDENTITY,
        [HasTweeters] bit NOT NULL,
        [HasSubWoofers] bit NOT NULL,
        [RadioId] nvarchar(50) NOT NULL,
        [InventoryId] int NOT NULL,
        [TimeStamp] rowversion NOT NULL,
        CONSTRAINT [PK_Radios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Radios_Inventory_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE INDEX [IX_Inventory_MakeId] ON [dbo].[Inventory] ([MakeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE INDEX [IX_InventoryToDrivers_DriverId] ON [dbo].[InventoryToDrivers] ([DriverId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_InventoryToDrivers_InventoryId_DriverId] ON [dbo].[InventoryToDrivers] ([InventoryId], [DriverId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Radios_CarId] ON [dbo].[Radios] ([InventoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520032907_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240520032907_Initial', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522165742_CustomSql'
)
BEGIN
    exec (N' 
        CREATE PROCEDURE [dbo].[GetPetName] @carID int, @petName nvarchar(50) output
        AS
        SELECT @petName = PetName from dbo.Inventory where Id = @carID')
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522165742_CustomSql'
)
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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522165742_CustomSql'
)
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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522165742_CustomSql'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240522165742_CustomSql', N'8.0.5');
END;
GO

COMMIT;
GO

