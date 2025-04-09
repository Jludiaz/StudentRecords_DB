CREATE TABLE Students (
    gwid INT PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    first VARCHAR(100),
    last VARCHAR(100),
    gender VARCHAR(10)
);

CREATE TABLE Scholarships (
    SID INT PRIMARY KEY,
    Length INT,
    Amount DECIMAL(10,2)
);

CREATE TABLE Has (
    GWID INT,
    SID INT,
    PRIMARY KEY (GWID, SID),
    FOREIGN KEY (GWID) REFERENCES Students(gwid),
    FOREIGN KEY (SID) REFERENCES Scholarships(SID)
);

CREATE TABLE Payments (
    pid INT PRIMARY KEY,
    payment_type VARCHAR(100),
    amount_due DECIMAL(10,2),
    due_date DATE
);

CREATE TABLE MustPay (
    GWID INT,
    PID INT,
    PRIMARY KEY (GWID, PID),
    FOREIGN KEY (GWID) REFERENCES Students(gwid),
    FOREIGN KEY (PID) REFERENCES Payments(pid)
);

CREATE TABLE Tracks (
    TID INT PRIMARY KEY,
    name VARCHAR(100) UNIQUE,
    degree_type VARCHAR(20)
);

CREATE TABLE MajorDepartment (
    name VARCHAR(100) PRIMARY KEY,
    department VARCHAR(100),
    FOREIGN KEY (name) REFERENCES Tracks(name)
);

CREATE TABLE IsA (
    GWID INT,
    TID INT,
    Since DATE,
    PRIMARY KEY (GWID, TID),
    FOREIGN KEY (GWID) REFERENCES Students(gwid),
    FOREIGN KEY (TID) REFERENCES Tracks(TID)
);

CREATE TABLE Courses (
    CRN INT PRIMARY KEY,
    requires VARCHAR(255),
    name VARCHAR(100),
    section VARCHAR(10),
    semester VARCHAR(20)
);

CREATE TABLE TrackRequires (
    TID INT,
    CRN INT,
    PRIMARY KEY (TID, CRN),
    FOREIGN KEY (TID) REFERENCES Tracks(TID),
    FOREIGN KEY (CRN) REFERENCES Courses(CRN)
);

CREATE TABLE Taking (
    GWID INT,
    CRN INT,
    grade CHAR(2),
    PRIMARY KEY (GWID, CRN),
    FOREIGN KEY (GWID) REFERENCES Students(gwid),
    FOREIGN KEY (CRN) REFERENCES Courses(CRN)
);
