
--Problem3_Create a function with parameters
USE BankAccounts
GO

CREATE FUNCTION fn_CalculateBankDeposit(@amount money, @yearlyInterest float, @months int) RETURNS money
AS
BEGIN
  RETURN @amount * POWER((1 + @yearlyInterest/ 12 / 100), @months)
  --RETURN (@finalAmount)
END
GO


USE BankAccounts
GO
SELECT dbo.fn_CalculateBankDeposit(1000, 12, 12) AS [money]


--Problem4_Create a stored procedure that uses the function from the previous example
USE BankAccounts
GO

CREATE PROC usp_AddMonthlyInterest(@accountId int, @interestRate float)
AS
	DECLARE @amount money, @newAmount money
	SELECT @amount = Balance FROM Accounts
	SELECT @newAmount = dbo.fn_CalculateBankDeposit(@amount, @interestRate, 1)

	UPDATE Accounts
	SET Balance = @newAmount
	WHERE Id = @accountId
GO

EXEC usp_AddMonthlyInterest 3, 12

--Problem5_Add two more stored procedures WithdrawMoney and DepositMoney

CREATE PROC usp_WithdrawMoney(@accountId int, @amountToWithdraw money)
AS
	BEGIN TRAN
		DECLARE @currentAmount money, @newAmount money
		SELECT @currentAmount = Balance FROM Accounts
		WHERE @accountId = PersonId

		IF (@currentAmount is NULL)
		BEGIN
			ROLLBACK TRAN
		END

		SET @newAmount = @currentAmount - @amountToWithdraw

		UPDATE Accounts
		SET Balance = @newAmount
		WHERE @accountId = Id

	COMMIT TRAN
GO

EXEC usp_WithdrawMoney 3, 2

CREATE PROC usp_DepositMoney(@accountId int, @amountToWithdraw money)
AS
	BEGIN TRAN
		DECLARE @currentAmount money, @newAmount money
		SELECT @currentAmount = Balance FROM Accounts
		WHERE @accountId = PersonId

		IF (@currentAmount is NULL)
		BEGIN
			ROLLBACK TRAN
		END

		SET @newAmount = @currentAmount + @amountToWithdraw

		UPDATE Accounts
		SET Balance = @newAmount
		WHERE @accountId = Id

	COMMIT TRAN
GO

EXEC usp_DepositMoney 3, 2

--Problem6_Create table Logs
USE BankAccounts
GO

CREATE TABLE Logs (
	Id int PRIMARY KEY IDENTITY NOT NULL,
	AccountId int,
	OldSum money,
	NewSum money
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId)
		REFERENCES Accounts(Id)
)

CREATE TRIGGER tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	IF UPDATE (Balance)
	BEGIN
		INSERT INTO Logs 
			SELECT i.Id, d.Balance, i.Balance
			FROM inserted i, deleted d	
	END
GO

EXEC usp_DepositMoney 3, 2

--Problem7_Define function in the SoftUni database

USE SoftUni
GO

CREATE FUNCTION fn_DoesStringContainAllLettersFromWord(@string varchar(MAX), @word varchar(MAX) ) RETURNS bit
AS
BEGIN
	IF (@word IS NULL)
	BEGIN
		RETURN 0;
	END

	DECLARE @length int = LEN(@word)
	DECLARE @index int = 1
	DECLARE @currentCharacter nvarchar(1)

	WHILE (@index <= @length)
	BEGIN
		SET @currentCharacter = SUBSTRING(@word, @index, 1)
		IF (@string NOT LIKE '%' + @currentCharacter +'%')
		BEGIN
			RETURN 0;
		END

		SET @index += 1
	END

	RETURN 1
END
GO

CREATE FUNCTION fn_TakeAllEmployeesAndTownsWhichLettersAreUntoString(@string varchar(MAX)) RETURNS TABLE
AS
	RETURN (
		SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS Name
		FROM Employees e
		WHERE (dbo.fn_DoesStringContainAllLettersFromWord(@string, e.FirstName) = 1 OR
			   dbo.fn_DoesStringContainAllLettersFromWord(@string, e.MiddleName) = 1 OR
			   dbo.fn_DoesStringContainAllLettersFromWord(@string, e.LastName) = 1 )
		UNION
		SELECT Name 
		FROM Towns t
		WHERE dbo.fn_DoesStringContainAllLettersFromWord(@string, t.Name) = 1
	)
GO

SELECT * FROM dbo.fn_TakeAllEmployeesAndTownsWhichLettersAreUntoString('oistmiahf')

--Problem8

DECLARE outCursor CURSOR READ_ONLY FOR
  SELECT TownId FROM Towns

OPEN outCursor
DECLARE @firstName varchar(50), @lastName varchar(50), @townName varchar(50)
FETCH NEXT FROM outCursor INTO @townName
PRINT @townName + ': '
WHILE @@FETCH_STATUS = 0
  BEGIN
	DECLARE inCursor CURSOR READ_ONLY FOR
	  
	  SELECT e.FirstName, e.LastName FROM Employees e
	  JOIN Addresses a ON e.AddressID = a.AddressID
	  JOIN Towns t ON t.TownID = a.TownID
	  WHERE t.Name = @townName
	  OPEN inCursor
      PRINT @firstName + ' ' + @lastName + ' '
      FETCH NEXT FROM inCursor 
      INTO @firstName, @lastName
	  CLOSE inCursor
  END
  FETCH NEXT FROM outCursor 
  INTO @townName
CLOSE outCursor
DEALLOCATE outCursor

