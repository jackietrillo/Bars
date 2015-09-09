CREATE TABLE [dbo].[MusicTypeBar] (
    [MusicTypeBarId] INT    IDENTITY (1, 1) NOT NULL,
    [BarId]			 INT    NOT NULL,
    [MusicTypeId]    INT    NOT NULL,  
    CONSTRAINT [PK_MuciTypeBar] PRIMARY KEY CLUSTERED ([MusicTypeBarId] ASC),
    CONSTRAINT [FK_MusicTypeBar_BarId] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId]),
    CONSTRAINT [FK_MusicTypeBar_MusicTypeId] FOREIGN KEY ([MusicTypeId]) REFERENCES [dbo].[MusicType] ([MusicTypeId])
);

