CREATE TABLE [dbo].[Bar] (
    [BarId]       INT            IDENTITY (1010, 10) NOT NULL,
    [DistrictId]  INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [ImageUrl]    VARCHAR (500)  NULL,
    [Latitude]    DECIMAL (9, 6) NULL,
    [Longitude]   DECIMAL (9, 6) NULL,
    [Address]     NVARCHAR (100) NULL,
    [Phone]       VARCHAR (50)   NULL,
    [Hours]       VARCHAR (50)   NULL,
    [WebsiteUrl]  VARCHAR (MAX)  NULL,
    [CalendarUrl] VARCHAR (MAX)  NULL,
    [FacebookUrl] VARCHAR (MAX)  NULL,
    [YelpUrl]     VARCHAR (MAX)  NULL,
    [LastUpdate]  DATETIME       NULL,
    [LastUserId]  INT            CONSTRAINT [DF_Bar_LastUser] DEFAULT (1000) NOT NULL,
    [CreateDate]  DATETIME       CONSTRAINT [DF_Bar_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [StatusFlag]  BIT            CONSTRAINT [DF_Bar_StatusFlag] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Bar] PRIMARY KEY CLUSTERED ([BarId] ASC),
    CONSTRAINT [FK_Bar_District] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([DistrictId]),
    CONSTRAINT [FK_Bar_User] FOREIGN KEY ([LastUserId]) REFERENCES [dbo].[User] ([UserId])
);

