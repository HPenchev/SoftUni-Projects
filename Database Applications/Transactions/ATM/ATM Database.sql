CREATE DATABASE ATM
GO

USE ATM
CREATE TABLE CardAccounts
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) UNIQUE,
	CardPIN CHAR(4),
	CardCash MONEY
)
GO

INSERT INTO CardAccounts VALUES
(6598956359, 9896, 200),
(8989995995, 2666, 1000),
(5949898494, 5995, 500),
(9849849849, 9195, 800),
(5195199999, 9998, 989)
GO

--Problem 6
USE ATM
CREATE TABLE TransactionHistory
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10),
	TransactionDate SMALLDATETIME,
	Amount MONEY
)
GO