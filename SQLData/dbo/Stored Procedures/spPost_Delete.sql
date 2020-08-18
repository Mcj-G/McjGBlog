CREATE PROCEDURE [dbo].[spPost_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from dbo.Comment
	where PostId = @Id;

	delete from dbo.Post
	where Id = @Id;
	
end
