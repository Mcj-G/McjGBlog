CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuthorId] NVARCHAR(128) NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Content] TEXT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Post_ToUser] FOREIGN KEY (AuthorId) REFERENCES [User](Id), 
    CONSTRAINT [FK_Post_ToCategory] FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
