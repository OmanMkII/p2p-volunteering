IF NOT EXISTS (SELECT 1 from sys.tables WHERE name ='Address')
CREATE TABLE [dbo].[Address] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CountryRegion]    NVARCHAR (255) NOT NULL,
    [Locality]         NVARCHAR (255) NOT NULL,
    [AdminDistrict]    NVARCHAR (255) NOT NULL,
    [AdminDistrict2]   NVARCHAR (255) NOT NULL,
    [Country]          NVARCHAR (255) NOT NULL,
    [HouseNumber]      NVARCHAR (255) NULL,
    [AddressLine]      NVARCHAR (255) NULL,
    [StreetName]       NVARCHAR (255) NULL,
    [FormattedAddress] NVARCHAR (255) NOT NULL,
    [Coords]           GEOGRAPHY      NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF NOT EXISTS (SELECT 1 from sys.tables WHERE name ='Volunteer')
CREATE TABLE [dbo].[Volunteer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(255) NOT NULL,
    [Type] VARCHAR(10) NOT NULL,
    [Id_Address] INT NOT NULL
)

IF OBJECT_ID('FK_Volunteer_Address') IS NULL
ALTER TABLE [dbo].[Volunteer]
    ADD CONSTRAINT [FK_Volunteer_Address] FOREIGN KEY ([Id_Address]) REFERENCES [dbo].[Address] ([Id]);