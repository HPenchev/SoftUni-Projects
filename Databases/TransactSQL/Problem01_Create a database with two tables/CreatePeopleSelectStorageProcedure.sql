USE BankAccounts
GO

CREATE PROC dbo.usp_SelectAllPeople
AS
	SELECT FirstName + ' ' + LastName
	FROM People
GO