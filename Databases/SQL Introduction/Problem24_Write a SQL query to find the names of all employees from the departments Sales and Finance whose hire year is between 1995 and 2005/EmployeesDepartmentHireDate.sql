SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name AS [Department], e.HireDate AS [Date of Hire]
FROM Employees e
	INNER JOIN Departments d
	ON (e.DepartmentID = d.DepartmentID
		AND d.Name IN('Sales', 'Finance')
		AND e.HireDate BETWEEN '1/1/1995' AND '12/31/2005')