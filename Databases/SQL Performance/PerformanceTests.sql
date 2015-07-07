CREATE TABLE PerformanceTest (
Id int IDENTITY PRIMARY KEY,
Date smalldatetime,
Text varchar(MAX)
)

DECLARE @i int = 0;
WHILE (@i < 10000000)
BEGIN
	INSERT INTO PerformanceTest VALUES (DATEADD(day, (ABS(CHECKSUM(NEWID())) % 65530), 0), 'some text')
END

SELECT * FROM PerformanceTest
WHERE Date BETWEEN '1950-01-01' AND '1990-12-31'

CREATE INDEX DateIndex
ON PerformanceTest (Date)

CHECKPOINT; 
GO 
DBCC DROPCLEANBUFFERS; 
DBCC FREEPROCCACHE
GO

CREATE INDEX DateIndex ON PerformanceTest (Date)