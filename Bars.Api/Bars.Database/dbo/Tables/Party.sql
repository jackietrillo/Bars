CREATE TABLE [dbo].[Party] (
    [PartyId]		INT            IDENTITY (1, 1) NOT NULL,
    [BarId]			INT            NULL,
    [Name]			NVARCHAR (100) NOT NULL,
	[Description]	NVARCHAR (MAX) NOT NULL,
    [Address]		NVARCHAR (150) NULL,
	[PartyDate]		DATETIME       NOT NULL,
    [LastUpdate]	DATETIME       NULL,
    [LastUserId]	INT            CONSTRAINT [DF_Party_LastUserId] DEFAULT ((1000)) NOT NULL,
    [CreateDate]	DATETIME       CONSTRAINT [DF_Party_CreateDate] DEFAULT (getutcdate()) NULL,
    [StatusFlag]	INT            CONSTRAINT [DF_Party_StatusFlag] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED ([PartyId] ASC),
    CONSTRAINT [FK_Party_Bar] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId]),
    CONSTRAINT [FK_Party_User] FOREIGN KEY ([LastUserId]) REFERENCES [dbo].[User] ([UserId])
);

