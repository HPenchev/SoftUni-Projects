SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees m
	RIGHT OUTER JOIN Employees e
	ON e.ManagerID = m.EmployeeID