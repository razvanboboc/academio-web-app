CREATE PROCEDURE [dbo].[spGetAllUsers]

AS
begin
    SELECT Id Id, 
           Username Username, 
           EmailAddress EmailAddress, 
           PasswordHash PasswordHash, 
           FirstName FirstName, 
           LastName LastName, 
           DateJoined DateJoined 
    FROM   dbo.[user]
End
