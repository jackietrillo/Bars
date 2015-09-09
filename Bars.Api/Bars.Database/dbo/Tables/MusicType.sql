CREATE TABLE [dbo].[MusicType] (
    [MusicTypeId] INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL, 
    CONSTRAINT [PK_MusicType] PRIMARY KEY CLUSTERED ([MusicTypeId] ASC)
);

