--SELECT d.Name, e.JobTitle, e.FirstName, MIN(e.Salary) AS [Min Salary] FROM Employees e 
--JOIN Departments d ON e.DepartmentID = d.DepartmentID 
--GROUP BY d.Name, e.JobTitle, e.FirstName

WITH summary as (
SELECT d.Name, e.JobTitle, e.FirstName, MIN(e.Salary) AS [Min Salary],


ROW_NUMBER() OVER(PARTITION BY e.JobTitle 
                                 ORDER BY e.Salary) rk


 FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID 
GROUP BY d.Name, e.JobTitle, e.FirstName, e.Salary)
SELECT s.Name AS [Department], s.JobTitle, s.FirstName, s.[Min Salary]
  FROM summary s
 WHERE s.rk = 1
 Order By Name