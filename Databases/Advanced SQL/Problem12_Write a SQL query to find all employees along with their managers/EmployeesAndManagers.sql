SELECT e.FirstName + ' ' + e.LastName AS [Employee], ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager] FROM Employees e
LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID
