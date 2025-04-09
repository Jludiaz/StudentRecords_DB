CREATE TABLE Students (
    gwid INT PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    first VARCHAR(100),
    last VARCHAR(100),
    gender VARCHAR(10)
);

CREATE TABLE Scholarships (
    sid INT PRIMARY KEY,
    length INT,
    amount DECIMAL(10,2)
);

CREATE TABLE Has (
    gwid INT,
    sid INT,
    PRIMARY KEY (gwid, sid),
    FOREIGN KEY (gwid) REFERENCES Students(gwid) ON DELETE CASCADE,
    FOREIGN KEY (sid) REFERENCES Scholarships(sid) ON DELETE CASCADE
);

CREATE TABLE Payments (
    pid INT PRIMARY KEY,
    payment_type VARCHAR(100),
    amount_due DECIMAL(10,2),
    due_date DATE
);

CREATE TABLE MustPay (
    gwid INT,
    pid INT,
    PRIMARY KEY (gwid, pid),
    FOREIGN KEY (gwid) REFERENCES Students(gwid) ON DELETE CASCADE,
    FOREIGN KEY (PID) REFERENCES Payments(pid) ON DELETE CASCADE
);

CREATE TABLE Tracks (
    tid INT PRIMARY KEY,
    name VARCHAR(100) UNIQUE,
    degree_type VARCHAR(20)
);

CREATE TABLE MajorDepartment (
    name VARCHAR(100) PRIMARY KEY,
    department VARCHAR(100),
    FOREIGN KEY (name) REFERENCES Tracks(name) ON DELETE CASCADE
);

CREATE TABLE IsA (
    gwid INT,
    tid INT,
    since DATE,
    PRIMARY KEY (gwid, tid),
    FOREIGN KEY (gwid) REFERENCES Students(gwid) ON DELETE CASCADE,
    FOREIGN KEY (tid) REFERENCES Tracks(tid) ON DELETE CASCADE
);

CREATE TABLE Courses (
    crn INT PRIMARY KEY,
    requires VARCHAR(255),
    name VARCHAR(100),
    section VARCHAR(10),
    semester VARCHAR(20)
);

CREATE TABLE TrackRequires (
    tid INT,
    crn INT,
    PRIMARY KEY (tid, crn),
    FOREIGN KEY (tid) REFERENCES Tracks(tid) ON DELETE CASCADE,
    FOREIGN KEY (crn) REFERENCES Courses(crn) ON DELETE CASCADE
);

CREATE TABLE Taking (
    gwid INT,
    crn INT,
    grade CHAR(2),
    PRIMARY KEY (gwid, crn),
    FOREIGN KEY (gwid) REFERENCES Students(gwid) ON DELETE CASCADE,
    FOREIGN KEY (crn) REFERENCES Courses(crn) ON DELETE CASCADE
);
