USE BankAccounts
GO

CREATE PROC usp_SelectEmployeesOverSomeLimit(
  @limit money)
AS
	SELECT p.FirstName + ' ' + p.LastName
	FROM People p
	JOIN Accounts a ON p.Id = a.PersonId
	WHERE a.Balance > @limit
GO

EXEC usp_SelectEmployeesOverSomeLimit 50