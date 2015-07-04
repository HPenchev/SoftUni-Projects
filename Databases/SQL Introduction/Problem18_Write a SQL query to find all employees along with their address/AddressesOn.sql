SELECT e.FirstName + ' ' + e.LastName AS [Employee], a.AddressText as [Address], t.Name AS [Town]
FROM Employees e 
	INNER JOIN Addresses a ON e.AddressID = a.AddressID
	INNER JOIN Towns t ON a.TownID = t.TownID