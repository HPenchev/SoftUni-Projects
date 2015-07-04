CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLogs(Command, 
							  TimeOfChange,
							  WorkHoursNewId,
							  NewEmployeeId,
							  NewDate,
							  NewTask,
							  NewHours,
							  NewComments)
	SELECT 'INSERT' AS Command, GETDATE() AS TimeOfChange, Id, EmployeeId, DateOfTask, Task, Hours, Comments
	FROM inserted
GO