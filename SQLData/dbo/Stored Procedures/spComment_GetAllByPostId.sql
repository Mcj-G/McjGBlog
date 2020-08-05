CREATE PROCEDURE [dbo].[spComment_GetAllByPostId]
	@PostId int
AS
begin
	set nocount on;

	select c.Id, c.PostId, u.FirstName as UserName, c.Content, c.CreatedDate
	from dbo.Comment c
	inner join dbo.[User] u on c.UserId = u.Id
	where c.PostId = @PostId;
	
end
