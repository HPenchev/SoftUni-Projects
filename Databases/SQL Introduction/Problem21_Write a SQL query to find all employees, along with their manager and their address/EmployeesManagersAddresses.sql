SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager], a.AddressText AS [Address], t.Name AS [Town]
FROM Employees e
	INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a ON e.AddressID = a.AddressID
	INNER JOIN Towns t ON a.TownID = t.TownID