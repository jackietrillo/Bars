CREATE TABLE [dbo].[User] (
    [UserId]           INT          IDENTITY (1, 1) NOT NULL,
    [UserName]         VARCHAR(50)  NOT NULL,
    [Password]         NVARCHAR(50) NULL,
    [Email]            VARCHAR(50)  NOT NULL,
    [FirstName]        NVARCHAR(50) NULL,
	[LastName]         NVARCHAR(50) NULL,
    [EmailIsVerified]  BIT          CONSTRAINT [DF_User_EmailIsVerified] DEFAULT ((0)) NOT NULL,
    [RegistrationDate] DATETIME     CONSTRAINT [DF_User_RegistrationDate] DEFAULT (GETUTCDATE()) NOT NULL,
    [LastLogOnDate]    DATETIME     CONSTRAINT [DF_User_LastLoginDate] DEFAULT (GETUTCDATE()) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED ([UserId] ASC)
);

GO

CREATE UNIQUE CLUSTERED INDEX [IX_User_Email]
    ON [dbo].[User]([Email] ASC);