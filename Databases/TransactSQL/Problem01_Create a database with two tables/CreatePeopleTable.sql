USE BankAccounts
GO
CREATE TABLE People (
Id int IDENTITY PRIMARY KEY NOT NULL,
FirstName varchar(50),
LastName varchar(50),
SSN varchar(50)
)