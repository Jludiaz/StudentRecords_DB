CREATE TRIGGER limit_course_enrollment
ON Taking
AFTER INSERT
AS
BEGIN
    IF EXISTS (
         SELECT 1
         FROM (
             SELECT t.gwid, c.semester, COUNT(*) AS course_count
             FROM Taking t
             INNER JOIN Courses c ON t.crn = c.crn
             WHERE t.gwid IN (SELECT DISTINCT gwid FROM inserted)
             GROUP BY t.gwid, c.semester
         ) AS Enrollment
         WHERE Enrollment.course_count > 6
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50000, 'Student cannot enroll in more than 6 courses per semester', 1;
    END
END;
GO

CREATE TRIGGER limit_scholarships
ON Has
AFTER INSERT
AS
BEGIN
    IF EXISTS (
         SELECT 1
         FROM (
             SELECT gwid, COUNT(*) AS scholarship_count
             FROM Has
             WHERE gwid IN (SELECT DISTINCT gwid FROM inserted)
             GROUP BY gwid
         ) AS SCounts
         WHERE SCounts.scholarship_count > 3
    )
    BEGIN
         ROLLBACK TRANSACTION;
         THROW 50001, 'Student cannot have more than 3 scholarships', 1;
    END
END;
GO
CREATE TRIGGER stop_course_self_requirement
ON Courses
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
         SELECT 1
         FROM inserted
         WHERE requires IS NOT NULL 
           AND requires = CAST(crn AS VARCHAR(255))
    )
    BEGIN
         ROLLBACK TRANSACTION;
         THROW 50003, 'A course cannot require itself.', 1;
    END
END;
