CREATE TABLE [dbo].[BarTypeBar] (
    [BarTypeBarId] INT      IDENTITY (1, 1) NOT NULL,
    [BarId]        INT      NOT NULL,
    [BarTypeId]    INT      NOT NULL,  
    CONSTRAINT [PK_BarTypeBar] PRIMARY KEY CLUSTERED ([BarTypeBarId] ASC),
    CONSTRAINT [FK_BarTypeBar_Bar] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId]),
    CONSTRAINT [FK_BarTypeBar_BarType] FOREIGN KEY ([BarTypeId]) REFERENCES [dbo].[BarType] ([BarTypeId])
);

