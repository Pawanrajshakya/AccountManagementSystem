Build started...
Build succeeded.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Balance' on entity type 'Account'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Balance' on entity type 'AccountHistory'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Amount' on entity type 'Transaction'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.

Build started...
Build succeeded.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Balance' on entity type 'Account'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Balance' on entity type 'AccountHistory'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
[40m[1m[33mwarn[39m[22m[49m: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Amount' on entity type 'Transaction'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AccountHistories] (
    [Id] int NOT NULL IDENTITY,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [Order] int NOT NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    CONSTRAINT [PK_AccountHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Businesses] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(255) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(5) NULL,
    [Description] nvarchar(255) NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Groups] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Relationships] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Relationships] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserActivities] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [DateRequested] datetime2 NOT NULL,
    [ControllerName] nvarchar(max) NULL,
    [ActionName] nvarchar(max) NULL,
    [Comment] nvarchar(max) NULL,
    CONSTRAINT [PK_UserActivities] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserHistories] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Name] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [UserRole] nvarchar(max) NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    CONSTRAINT [PK_UserHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [UserName] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Name] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(max) NULL,
    [BusinessId] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AccountTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [GroupId] int NOT NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AccountTypes_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Account] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_AccountTypes_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Relationships_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [Relationships] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TransactionTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionTypes_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [TransactionDate] datetime2 NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Description1] nvarchar(255) NULL,
    [Description2] nvarchar(255) NULL,
    [TransactionTypeId] int NOT NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Transactions_TransactionTypes_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [TransactionTypes] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address1', N'Address2', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name', N'State', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Businesses]'))
    SET IDENTITY_INSERT [Businesses] ON;
INSERT INTO [Businesses] ([Id], [Address1], [Address2], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Name], [State], [ZipCode])
VALUES (1, N'Address 1', N'Address 2', 0, '2020-04-27T15:32:58.0606480-04:00', NULL, CAST(1 AS bit), CAST(1 AS bit), 0, '2020-04-27T15:32:58.0606500-04:00', N'Business Name', N'zz', N'zzzzz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address1', N'Address2', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name', N'State', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Businesses]'))
    SET IDENTITY_INSERT [Businesses] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Order') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Order])
VALUES (1, 0, '2020-04-27T15:32:58.0610460-04:00', N'New Group', CAST(1 AS bit), CAST(1 AS bit), 0, '2020-04-27T15:32:58.0610480-04:00', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Order') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (1, 0, '2020-04-27T15:32:58.0467380-04:00', N'Admin', CAST(1 AS bit), CAST(1 AS bit), 0, '2020-04-27T15:32:58.0589090-04:00'),
(2, 0, '2020-04-27T15:32:58.0592450-04:00', N'User', CAST(1 AS bit), CAST(1 AS bit), 0, '2020-04-27T15:32:58.0592490-04:00'),
(3, 0, '2020-04-27T15:32:58.0592560-04:00', N'Viewer', CAST(1 AS bit), CAST(1 AS bit), 0, '2020-04-27T15:32:58.0592560-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

CREATE INDEX [IX_Account_AccountTypeId] ON [Account] ([AccountTypeId]);

GO

CREATE INDEX [IX_Account_ClientId] ON [Account] ([ClientId]);

GO

CREATE INDEX [IX_Account_RelationshipId] ON [Account] ([RelationshipId]);

GO

CREATE INDEX [IX_AccountTypes_GroupId] ON [AccountTypes] ([GroupId]);

GO

CREATE INDEX [IX_Clients_BusinessId] ON [Clients] ([BusinessId]);

GO

CREATE INDEX [IX_Transactions_AccountId] ON [Transactions] ([AccountId]);

GO

CREATE INDEX [IX_Transactions_TransactionTypeId] ON [Transactions] ([TransactionTypeId]);

GO

CREATE INDEX [IX_TransactionTypes_AccountId] ON [TransactionTypes] ([AccountId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200427193258_InitalCreateDB', N'3.1.2');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Gender');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] DROP COLUMN [Gender];

GO

ALTER TABLE [Users] ADD [LastPasswordChangedOn] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [PasswordChangedCount] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Users] ADD [Phone] nvarchar(max) NULL;

GO

UPDATE [Businesses] SET [CreatedDate] = '2020-06-09T15:06:16.9766180-04:00', [LastModifiedDate] = '2020-06-09T15:06:16.9766200-04:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Groups] SET [CreatedDate] = '2020-06-09T15:06:16.9769890-04:00', [LastModifiedDate] = '2020-06-09T15:06:16.9769900-04:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Roles] SET [CreatedDate] = '2020-06-09T15:06:16.9607360-04:00', [LastModifiedDate] = '2020-06-09T15:06:16.9746590-04:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Roles] SET [CreatedDate] = '2020-06-09T15:06:16.9750610-04:00', [LastModifiedDate] = '2020-06-09T15:06:16.9750640-04:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Roles] SET [CreatedDate] = '2020-06-09T15:06:16.9750710-04:00', [LastModifiedDate] = '2020-06-09T15:06:16.9750710-04:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200609190617_user_changes', N'3.1.2');

GO


