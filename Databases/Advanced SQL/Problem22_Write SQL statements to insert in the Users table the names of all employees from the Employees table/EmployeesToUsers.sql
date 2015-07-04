INSERT INTO Users (FullName, Username, Password)
	SELECT FirstName + ' ' + LastName, LOWER(SUBSTRING(FirstName, 1, 3) + LastName), LOWER(SUBSTRING(FirstName, 1, 3) + LastName)
	FROM Employees
