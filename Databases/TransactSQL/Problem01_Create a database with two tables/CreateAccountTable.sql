USE BankAccounts
GO
CREATE TABLE Accounts (
Id int IDENTITY PRIMARY KEY NOT NULL,
PersonId int,
Balance money DEFAULT(0)
CONSTRAINT FK_Accounts_People FOREIGN KEY(PersonId)
    REFERENCES People(Id)
)