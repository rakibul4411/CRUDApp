# CRUDApp
Demo CRUD App Using SQL Stored procedure

## SQL Query
1. CREATE a database Nane [CRUDApp]. Then run the below SQL Query
USE [CRUDApp]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 7/23/2023 12:37:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[FatherName] [varchar](100) NULL,
	[EmployeeCode] [varchar](10) NOT NULL,
	[Address] [varchar](500) NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_EMPLOYEE_BASIC]    Script Date: 7/23/2023 12:37:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DELETE_EMPLOYEE_BASIC]
@Id INT
AS
BEGIN
 DELETE FROM Employees  WHERE Id = @Id
 SELECT 'Delete Successful'[message]
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ALLEMPLOYEE]    Script Date: 7/23/2023 12:37:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GET_ALLEMPLOYEE]
AS
BEGIN
 SELECT * FROM Employees
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ALLEMPLOYEEBYID]    Script Date: 7/23/2023 12:37:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GET_ALLEMPLOYEEBYID]
@Id INT
AS
BEGIN
 SELECT * FROM Employees E WHERE E.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_EMPLOYEE_BASIC]    Script Date: 7/23/2023 12:37:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INSERT_EMPLOYEE_BASIC]
@EmpCode VARCHAR(10),
@EmpName VARCHAR(10),
@EmpFatherName VARCHAR(10),
@Address VARCHAR(500),
@Id INT = 0
AS
BEGIN
IF @Id <> 0
BEGIN
	UPDATE Employees SET EmployeeCode = @EmpCode,[Name] = @EmpName,FatherName = @EmpFatherName,[Address] = @Address
	WHERE Id = @Id
	SELECT 'Update Successful'[message]
END
ELSE
BEGIN
    INSERT INTO Employees (EmployeeCode,[Name],FatherName,[Address])
	VALUES (@EmpCode,@EmpName,@EmpFatherName,@Address)
	SELECT 'Save Successful'[message]
END
END
GO

