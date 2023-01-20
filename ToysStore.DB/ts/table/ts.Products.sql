CREATE TABLE [ts].[Products] (
    [Id]              UNIQUEIDENTIFIER   CONSTRAINT [DF_Products_Id] DEFAULT (NEWID()) NOT NULL,
    [Name]            NVARCHAR (50)      NOT NULL,
    [Description]     NVARCHAR (100)     NOT NULL,
    [RestrictionAge]  INT                NOT NULL,
    [Price]           DECIMAL (7,2)      NOT NULL,
    [CompanyId]       UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PKId_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKComapanyId_Products_PKId_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [ts].[Companies] ([Id])
);