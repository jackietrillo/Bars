CREATE TABLE [dbo].[UserRole]
(
	[UserRoleId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId]	 INT NOT NULL, 
    [RoleId]	 INT NOT NULL,
	CONSTRAINT [FK_UserRole_User] FOREIGN KEY (UserId) REFERENCES [dbo].[User] ([UserId]),
	CONSTRAINT [FK_UserRole_Role] FOREIGN KEY (UserId) REFERENCES [dbo].[Role] ([RoleId])
)
