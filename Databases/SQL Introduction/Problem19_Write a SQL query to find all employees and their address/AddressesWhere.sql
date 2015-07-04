SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText AS [Address], t.Name AS [Town]
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND t.TownID = a.TownId