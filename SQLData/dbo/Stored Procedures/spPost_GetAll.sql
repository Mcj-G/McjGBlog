CREATE PROCEDURE [dbo].[spPost_GetAll]

AS
begin
	set nocount on;

	select [Id], [AuthorId], [Title], [Content], [CreatedDate], [CategoryId]
	from dbo.Post;
	
end
