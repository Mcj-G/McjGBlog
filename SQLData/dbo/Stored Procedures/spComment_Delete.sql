CREATE PROCEDURE [dbo].[spComment_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from dbo.Comment
	where Id = @Id;
	
end
