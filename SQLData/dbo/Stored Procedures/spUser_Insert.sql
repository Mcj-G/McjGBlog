CREATE PROCEDURE [dbo].[spUser_Insert]
	@Id nvarchar(128),
	@FirstName nvarchar(30),
	@EmailAddress nvarchar(100)
AS
begin
	SET NOCOUNT ON

	insert into dbo.[User](Id, FirstName, EmailAddress)
	values (@Id, @FirstName, @EmailAddress)

end
