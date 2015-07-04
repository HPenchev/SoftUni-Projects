SELECT AVG(Salary) AS [Average salary in Sales] FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID 
	AND d.Name = 'Sales'