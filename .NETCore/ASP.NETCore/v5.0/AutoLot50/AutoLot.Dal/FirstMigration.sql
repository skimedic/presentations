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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE TABLE [Makes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Makes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE TABLE [CreditRisks] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [CustomerId] int NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_CreditRisks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CreditRisks_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE TABLE [Inventory] (
        [Id] int NOT NULL IDENTITY,
        [MakeId] int NOT NULL,
        [Color] nvarchar(50) NOT NULL,
        [PetName] nvarchar(50) NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Make_Inventory] FOREIGN KEY ([MakeId]) REFERENCES [Makes] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [CustomerId] int NOT NULL,
        [CarId] int NOT NULL,
        [TimeStamp] rowversion NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY ([CarId]) REFERENCES [Inventory] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE INDEX [IX_CreditRisks_CustomerId] ON [CreditRisks] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE INDEX [IX_Inventory_MakeId] ON [Inventory] ([MakeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE INDEX [IX_Orders_CarId] ON [Orders] ([CarId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Orders_CustomerId_CarId] ON [Orders] ([CustomerId], [CarId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201231203939_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201231203939_Initial', N'5.0.1');
END;
GO

COMMIT;
GO

