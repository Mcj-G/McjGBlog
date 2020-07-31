CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PostId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Content] TEXT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Comment_ToPost] FOREIGN KEY (PostId) REFERENCES Post(Id), 
    CONSTRAINT [FK_Comment_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id)
)
