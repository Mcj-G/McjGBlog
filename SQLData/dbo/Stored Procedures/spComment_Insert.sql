CREATE PROCEDURE [dbo].[spComment_Insert]
	@Id int output,
	@PostId int,
	@UserId nvarchar(128),
	@Content text,
	@CreatedDate datetime2
	
AS
begin
	SET NOCOUNT ON

	insert into dbo.Comment(PostId, UserId, Content, CreatedDate)
	values (@PostId, @UserId, @Content, @CreatedDate)
	
	select @Id = SCOPE_IDENTITY();

end
