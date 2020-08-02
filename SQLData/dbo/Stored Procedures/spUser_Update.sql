CREATE PROCEDURE [dbo].[spUser_Update]
	@Id nvarchar(128),
	@FirstName nvarchar(30),
	@EmailAddress nvarchar(100)
AS
begin
	SET NOCOUNT ON

	update dbo.[User]
	set FirstName = @FirstName
	where Id = @Id;

end
