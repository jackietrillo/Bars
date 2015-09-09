CREATE TABLE [dbo].[Event] (
    [EventId]		INT            IDENTITY (1, 1) NOT NULL,
    [BarId]			INT            NULL,
    [Name]			NVARCHAR (100) NOT NULL,
	[Description]	NVARCHAR (MAX) NOT NULL,
    [Address]		NVARCHAR (150) NULL,
    [EventDate]		DATETIME       NOT NULL,
    [LastUpdate]	DATETIME       NULL,
    [LastUserId]	INT            CONSTRAINT [DF_Event_LastUser] DEFAULT (1000) NOT NULL,
    [CreateDate]	DATETIME       CONSTRAINT [DF_Event_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [StatusFlag]	INT            CONSTRAINT [DF_Event_StatusFlag] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [FK_Event_Bar] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId]),
    CONSTRAINT [FK_Event_User] FOREIGN KEY ([LastUserId]) REFERENCES [dbo].[User] ([UserId])
);

