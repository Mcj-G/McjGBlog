CREATE PROCEDURE [dbo].[spPost_Insert]
	@Id int output,
	@AuthorId nvarchar(128),
	@Title nvarchar(100),
	@Content text,
	@CreatedDate datetime2,
	@CategoryId int
AS
begin
	SET NOCOUNT ON

	insert into dbo.Post(AuthorId, Title, Content, CreatedDate, CategoryId)
	values (@AuthorId, @Title, @Content, @CreatedDate, @CategoryId)
	
	select @Id = SCOPE_IDENTITY();

end
