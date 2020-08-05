CREATE PROCEDURE [dbo].[spPost_GetAll]

AS
begin
	set nocount on;

	select [p].[Id], [u].[FirstName] as AuthorName, [p].[Title], [p].[Content], [p].[CreatedDate], [c].[Name] as CategoryName
	from (([dbo].[Post] as [p]
	inner join [dbo].[User] as [u] on [p].[AuthorId] = [u].[Id])
	inner join [dbo].[Category] as [c] on [p].[CategoryId] =  [c].[Id]);
	
end
