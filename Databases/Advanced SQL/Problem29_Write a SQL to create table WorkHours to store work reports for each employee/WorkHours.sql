CREATE TABLE WorkHours (
Id int IDENTITY PRIMARY KEY,
EmployeeId int,
DateOfTask smalldatetime,
Task varchar(200),
Hours float,
Comments varchar(MAX)
CONSTRAINT FK_WorkHours_Employees
	FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeID)
)
