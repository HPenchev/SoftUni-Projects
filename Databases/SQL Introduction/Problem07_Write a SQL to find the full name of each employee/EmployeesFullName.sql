SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName  AS [Full Name]
 FROM Employees