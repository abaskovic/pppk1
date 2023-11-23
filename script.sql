


CREATE TABLE Student (
    IdStudent INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Oib NVARCHAR(20),
    Email NVARCHAR(50),
    Picture VARBINARY(MAX)
);

CREATE TABLE Professor (
    IdProfessor INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Oib NVARCHAR(20),
    Email NVARCHAR(50)
);

CREATE TABLE Subject (
    IdSubject INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50)
);

CREATE TABLE Exam (
    IdExam INT PRIMARY KEY IDENTITY,
    IdStudent INT,
    IdProfessor INT,
    Mark INT,
    IdSubject INT,
    FOREIGN KEY (IdStudent) REFERENCES Student(IdStudent),
    FOREIGN KEY (IdProfessor) REFERENCES Professor(IdProfessor),
    FOREIGN KEY (IdSubject) REFERENCES Subject(idSubject)
);
GO
CREATE PROC GetStudent
    @IdStudent INT
AS SELECT * FROM Student WHERE IdStudent = @IdStudent;
GO

CREATE PROC GetProfessor
    @IdProfessor INT
AS SELECT * FROM Professor WHERE IdProfessor = @IdProfessor;
GO

CREATE PROC GetExam
    @IdExam INT
AS SELECT * FROM Exam WHERE IdExam = @IdExam;
GO

CREATE PROC GetExams
AS SELECT Exam.*, Subject.Name AS SubjectName FROM Exam  INNER JOIN Subject ON Exam.IdSubject=Subject.IdSubject;
GO


CREATE PROC GetSubject
    @IdSubject INT
AS SELECT * FROM Subject WHERE IdSubject = @IdSubject;
GO

CREATE PROC GetSubjects
AS SELECT * FROM Subject;
GO

CREATE PROC GetStudents
AS SELECT * FROM Student;
GO
CREATE PROC GetProfessors
AS SELECT * FROM Professor;
GO

CREATE PROC DeleteStudent
    @IdStudent INT
AS DELETE FROM Student WHERE IdStudent = @IdStudent;
GO

CREATE PROC DeleteProfessor
    @IdProfessor INT
AS DELETE FROM Professor WHERE IdProfessor = @IdProfessor;
GO

CREATE PROC DeleteExam
    @IdExam INT
AS DELETE FROM Exam WHERE IdExam = @IdExam;
GO

CREATE PROC AddStudent
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Oib NVARCHAR(20),
    @Email NVARCHAR(50),
    @Picture VARBINARY(MAX),
	@idStudent INT OUTPUT

AS
INSERT INTO Student 
VALUES (@FirstName, @LastName, @Oib, @Email, @Picture)
SET @idStudent = SCOPE_IDENTITY()
GO

CREATE PROC UpdateStudent
    @IdStudent INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Oib NVARCHAR(20),
    @Email NVARCHAR(50),
    @Picture VARBINARY(MAX)
AS
UPDATE Student
SET
    FirstName = @FirstName,
    LastName = @LastName,
    Oib = @Oib,
    Email = @Email,
    Picture = @Picture
WHERE IdStudent = @IdStudent;
GO

CREATE PROC AddProfessor
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Oib NVARCHAR(20),
    @Email NVARCHAR(50),
	@idProfessor INT OUTPUT

AS
INSERT INTO Professor 
VALUES (@FirstName, @LastName, @Oib, @Email)
SET @idProfessor = SCOPE_IDENTITY()
GO

CREATE PROC UpdateProfessor
    @IdProfessor INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Oib NVARCHAR(20),
    @Email NVARCHAR(50)
AS
UPDATE Professor
SET
    FirstName = @FirstName,
    LastName = @LastName,
    Oib = @Oib,
    Email = @Email
WHERE IdProfessor = @IdProfessor;
GO

CREATE PROC AddExam
    @IdStudent INT,
    @IdProfessor INT,
    @Mark INT,
    @IdSubject INT,
	@idExam INT OUTPUT

AS
INSERT INTO Exam 
VALUES (@IdStudent, @IdProfessor, @Mark, @IdSubject)
SET @idExam = SCOPE_IDENTITY()
GO

CREATE PROC UpdateExam
    @IdExam INT,
    @IdStudent INT,
    @IdProfessor INT,
    @Mark INT,
    @IdSubject INT
AS
UPDATE Exam
SET
    IdStudent = @IdStudent,
    IdProfessor = @IdProfessor,
    Mark = @Mark,
    IdSubject = @IdSubject
WHERE IdExam = @IdExam;
GO




INSERT INTO Professor (FirstName, LastName, Oib, Email)
VALUES
    ('Iva', 'Ivic', '87654321098', 'iva@gmail.com'),
    ('Mia', 'Petric', '11122334455', 'mia@gmail.com'),
    ('Ivan', 'Mijic', '87654321987', 'ivan@gmail.com');

INSERT INTO Subject (Name)
VALUES
    ('Matematika'),
    ('PPPK'),
    ('Java 2');

INSERT INTO Exam (IdStudent, IdProfessor, Mark, IdSubject)
VALUES
    (8, 1, 5, 1),
    (9, 2, 2, 2),
    (7, 3, 3, 3);



	GO
exec GetStudents

exec GetProfessors