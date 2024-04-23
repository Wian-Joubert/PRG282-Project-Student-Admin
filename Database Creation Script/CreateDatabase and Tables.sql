IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BCStudents')
BEGIN
    CREATE DATABASE BCStudents;
END
GO

USE BCStudents;
GO

-- Create the Students table
CREATE TABLE Students
(
    StudentNumber INT PRIMARY KEY,
    Name NVARCHAR(25),
    Surname NVARCHAR(25),
    Gender NVARCHAR(10),
    DOB DATE,
    PhoneNumber NVARCHAR(10),
    Address NVARCHAR(30),
    ModuleCodes NVARCHAR(MAX),
    ImageData NVARCHAR(MAX)
);

CREATE TABLE ModuleInformation (
    ModuleName NVARCHAR(30) NOT NULL,
    ModuleCode VARCHAR(20) PRIMARY KEY,
    ModuleDesc NVARCHAR(MAX),
    LinksToResources NVARCHAR(MAX)
);
GO