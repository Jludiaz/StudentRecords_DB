-- Populate Students
INSERT INTO Students (gwid, email, first, last, gender) VALUES 
(10001, 'john@gwu.edu', 'John', 'Smith', 'Male'),
(10002, 'sarah@gwu.edu', 'Sarah', 'Jones', 'Female'),
(10003, 'michael@gwu.edu', 'Michael', 'Brown', 'Male'),
(10004, 'emily@gwu.edu', 'Emily', 'Davis', 'Female'),
(10005, 'billy@gwu.edu', 'Bill', 'Wilson', 'Male'),
(10006, 'jessica@gwu.edu', 'Jessica', 'Taylor', 'Female'),
(10007, 'ryan@gwu.edu', 'Ryan', 'Anderson', 'Male'),
(10008, 'olivia@gwu.edu', 'Olivia', 'Miller', 'Female'),
(10009, 'daniel@gwu.edu', 'Daniel', 'Moore', 'Male'),
(10010, 'sophia@gwu.edu', 'Sophia', 'Jackson', 'Female');

-- Populate Scholarships
INSERT INTO Scholarships (sid, length, amount) VALUES
(1, 4, 10000.00),
(2, 2, 5000.00),
(3, 1, 2500.00),
(4, 4, 15000.00),
(5, 3, 7500.00);

-- Populate Has (Students with Scholarships)
INSERT INTO Has (gwid, sid) VALUES
(10001, 1),
(10002, 2),
(10003, 3),
(10005, 4),
(10008, 5),
(10010, 1);

-- Populate Payments
INSERT INTO Payments (pid, payment_type, amount_due, due_date) VALUES
(1, 'Tuition', 12000.00, '2025-01-15'),
(2, 'Housing', 8000.00, '2025-01-20'),
(3, 'Books', 500.00, '2025-01-25'),
(4, 'Meal Plan', 2500.00, '2025-01-20'),
(5, 'Technology Fee', 300.00, '2025-01-15'),
(6, 'Lab Fee', 150.00, '2025-01-25');

-- Populate MustPay
INSERT INTO MustPay (gwid, pid) VALUES
(10001, 1), (10001, 3),
(10002, 1), (10002, 2), (10002, 4),
(10003, 1), (10003, 5),
(10004, 1), (10004, 3), (10004, 6),
(10005, 1), (10005, 2),
(10006, 1), (10006, 4), (10006, 5),
(10007, 1), (10007, 3),
(10008, 1), (10008, 2), (10008, 4),
(10009, 1), (10009, 5), (10009, 6),
(10010, 1), (10010, 2);

-- Populate Tracks
INSERT INTO Tracks (tid, name, degree_type) VALUES
(1, 'Computer Science', 'BS'),
(2, 'Political Science', 'BA'),
(3, 'Business Administration', 'BBA'),
(4, 'Mechanical Engineering', 'BS'),
(5, 'English Literature', 'BA'),
(6, 'Biology', 'BS'),
(7, 'Economics', 'BA'),
(8, 'Chemistry', 'BS');

-- Populate MajorDepartment
INSERT INTO MajorDepartment (name, department) VALUES
('Computer Science', 'Engineering'),
('Political Science', 'Social Sciences'),
('Business Administration', 'Business'),
('Mechanical Engineering', 'Engineering'),
('English Literature', 'Arts & Humanities'),
('Biology', 'Natural Sciences'),
('Economics', 'Social Sciences'),
('Chemistry', 'Natural Sciences');

-- Populate IsA (Student Tracks)
INSERT INTO IsA (gwid, tid, since) VALUES
(10001, 1, '2023-08-25'),
(10002, 5, '2023-08-25'),
(10003, 3, '2022-08-26'),
(10004, 6, '2022-08-26'),
(10005, 4, '2024-01-10'),
(10006, 2, '2021-08-27'),
(10007, 7, '2021-08-27'),
(10008, 1, '2023-08-25'),
(10009, 8, '2022-08-26'),
(10010, 3, '2024-01-10');

-- Populate Courses
INSERT INTO Courses (crn, requires, name, section, semester) VALUES
(20101, 'None', 'Introduction to Programming', '01', 'Spring 2025'),
(20102, 'CRN 20101', 'Data Structures', '01', 'Spring 2025'),
(20103, 'CRN 20102', 'Algorithms', '01', 'Spring 2025'),
(20201, 'None', 'American Government', '01', 'Spring 2025'),
(20202, 'CRN 20201', 'International Relations', '01', 'Spring 2025'),
(20301, 'None', 'Principles of Management', '01', 'Spring 2025'),
(20302, 'CRN 20301', 'Marketing Fundamentals', '01', 'Spring 2025'),
(20401, 'None', 'Engineering Mechanics', '01', 'Spring 2025'),
(20402, 'CRN 20401', 'Thermodynamics', '01', 'Spring 2025'),
(20501, 'None', 'Introduction to Literary Analysis', '01', 'Spring 2025'),
(20601, 'None', 'General Biology', '01', 'Spring 2025'),
(20602, 'CRN 20601', 'Cell Biology', '01', 'Spring 2025'),
(20701, 'None', 'Microeconomics', '01', 'Spring 2025'),
(20702, 'CRN 20701', 'Macroeconomics', '01', 'Spring 2025'),
(20801, 'None', 'General Chemistry', '01', 'Spring 2025'),
(20802, 'CRN 20801', 'Organic Chemistry', '01', 'Spring 2025');

-- Populate TrackRequires
INSERT INTO TrackRequires (tid, crn) VALUES
(1, 20101), (1, 20102), (1, 20103),
(2, 20201), (2, 20202),
(3, 20301), (3, 20302),
(4, 20401), (4, 20402),
(5, 20501),
(6, 20601), (6, 20602),
(7, 20701), (7, 20702),
(8, 20801), (8, 20802);

-- Populate Taking
INSERT INTO Taking (gwid, crn, grade) VALUES
(10001, 20101, 'A'), (10001, 20102, 'B+'),
(10002, 20501, 'A-'),
(10003, 20301, 'B'), (10003, 20302, 'B+'),
(10004, 20601, 'A'), (10004, 20602, 'A-'),
(10005, 20401, 'B+'),
(10006, 20201, 'A-'), (10006, 20202, 'B'),
(10007, 20701, 'B+'), (10007, 20702, 'A-'),
(10008, 20101, 'A'), (10008, 20102, 'A-'),
(10009, 20801, 'B+'), (10009, 20802, 'B'),
(10010, 20301, 'A-');