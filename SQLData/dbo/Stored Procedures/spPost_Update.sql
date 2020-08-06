CREATE PROCEDURE [dbo].[spPost_Update]
	@Id int,
	@Title nvarchar(100),
	@Content text
AS
begin
	SET NOCOUNT ON

	update dbo.Post
	set Title = @Title, Content = @Content
	where Id = @Id;

end
