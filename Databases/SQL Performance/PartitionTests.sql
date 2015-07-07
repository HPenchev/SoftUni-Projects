#Creating table

CREATE TABLE performance_test (
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
date DATETIME,
text VARCHAR(500)
)

PARTITION BY RANGE (YEAR(date)) (
    PARTITION 90s VALUES LESS THAN (2001),
    PARTITION 2000s VALUES LESS THAN (2011),
    PARTITION 2010s VALUES LESS THAN (2021)
);

#Creating procedure for inserting random dates by loop

DELIMITER //

CREATE PROCEDURE fill_table()
BEGIN
  SET @p1 = 0;
  label1: LOOP
  INSERT INTO `performance_test`(date, text) VALUES(
		FROM_UNIXTIME(
			UNIX_TIMESTAMP('1991-01-01 00:00:00') + FLOOR(0 + (RAND() * 946771200 ))
		), 'some text'
	);
    SET @p1 = @p1 + 1;
    IF @p1 < 1000000 THEN
      ITERATE label1;
    END IF;
    LEAVE label1;
  END LOOP label1;
  
END;
  
  
DELIMITER ;
 
CALL fill_table();

#Testing search in whole table and partition. It is strange but full search took 17 seconds while partition took 19

RESET QUERY CACHE;
SELECT date, text FROM performance_test
WHERE date BETWEEN '2004-09-19' AND '2004-09-20';

RESET QUERY CACHE;

SELECT date, text FROM performance_test PARTITION (2000s)
WHERE date BETWEEN '2004-09-19' AND '2004-09-20';
    
    


 