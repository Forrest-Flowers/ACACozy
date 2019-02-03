IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Landlords] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Landlords] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Tenants] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Income] float NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Tenants] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Homes] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [ImageURL] nvarchar(max) NULL,
    [LandlordId] nvarchar(450) NULL,
    CONSTRAINT [PK_Homes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Homes_Landlords_LandlordId] FOREIGN KEY ([LandlordId]) REFERENCES [Landlords] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Leases] (
    [Id] int NOT NULL IDENTITY,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [RentPrice] float NOT NULL,
    [HomeId] int NOT NULL,
    [TenantId] nvarchar(450) NULL,
    CONSTRAINT [PK_Leases] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Leases_Homes_HomeId] FOREIGN KEY ([HomeId]) REFERENCES [Homes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Leases_Tenants_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [Tenants] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Maintenances] (
    [Id] int NOT NULL IDENTITY,
    [Status] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [HomeId] int NOT NULL,
    [TenantId] nvarchar(450) NULL,
    CONSTRAINT [PK_Maintenances] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Maintenances_Homes_HomeId] FOREIGN KEY ([HomeId]) REFERENCES [Homes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Maintenances_Tenants_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [Tenants] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Payments] (
    [Id] int NOT NULL IDENTITY,
    [PaidOn] datetime2 NOT NULL,
    [Amount] float NOT NULL,
    [TenantId] nvarchar(450) NULL,
    [LeaseId] int NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Leases_LeaseId] FOREIGN KEY ([LeaseId]) REFERENCES [Leases] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Tenants_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [Tenants] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Homes_LandlordId] ON [Homes] ([LandlordId]);

GO

CREATE INDEX [IX_Leases_HomeId] ON [Leases] ([HomeId]);

GO

CREATE INDEX [IX_Leases_TenantId] ON [Leases] ([TenantId]);

GO

CREATE INDEX [IX_Maintenances_HomeId] ON [Maintenances] ([HomeId]);

GO

CREATE INDEX [IX_Maintenances_TenantId] ON [Maintenances] ([TenantId]);

GO

CREATE INDEX [IX_Payments_LeaseId] ON [Payments] ([LeaseId]);

GO

CREATE INDEX [IX_Payments_TenantId] ON [Payments] ([TenantId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190131023536_initial', N'2.1.4-rtm-31024');

GO

