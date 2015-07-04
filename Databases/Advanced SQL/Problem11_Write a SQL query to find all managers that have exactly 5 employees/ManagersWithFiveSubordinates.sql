SELECT m.FirstName, m.LastName, COUNT(*) AS [Number of Subordinates] FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5
