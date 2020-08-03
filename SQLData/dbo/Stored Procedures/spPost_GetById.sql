CREATE PROCEDURE [dbo].[spPost_GetById]
	@Id int
AS
begin
	set nocount on;

	select [Id], [AuthorId], [Title], [Content], [CreatedDate], [CategoryId]
	from dbo.Post
	where Id = @Id;
	
end
