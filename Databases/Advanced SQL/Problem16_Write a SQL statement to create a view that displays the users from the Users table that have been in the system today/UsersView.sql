CREATE VIEW UsersList AS
SELECT Username, FullName, LastLogin FROM Users
WHERE CONVERT(date, GETDATE()) = CONVERT(date, LastLogin)