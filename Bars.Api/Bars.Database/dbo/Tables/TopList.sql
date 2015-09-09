CREATE TABLE [dbo].[TopList] (
    [TopListId]  INT      IDENTITY (1, 1) NOT NULL,
    [BarId]      INT      NOT NULL,
    [Rank]       TINYINT  NOT NULL,  
    CONSTRAINT [PK_TopList] PRIMARY KEY CLUSTERED ([TopListId] ASC),
    CONSTRAINT [FK_TopList_Bar] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId])
);

