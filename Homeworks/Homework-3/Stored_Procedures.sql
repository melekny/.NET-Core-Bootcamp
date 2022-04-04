USE LogoDb
GO
-- =============================================
-- Author:		Meleknur Yazlamaz
-- Create date: 27/03/2022
-- Description:	Insert, Update and Delete Query Based Stored Procedures for User&Company Tables
-- =============================================

--Defining the Insert Stored Procedures

CREATE PROCEDURE stpInsertUser
	-- Adding the parameters for the stored procedure
	@FirstName nvarchar(50),
	@LastName nvarchar(30),
	@Email varchar(20),
	@Address varchar(200),
	@PhoneNumber varchar(20),
	@Password varchar(20),
	@Company_Id int
	
AS
BEGIN

    -- Insert statements for procedure 
	INSERT INTO User (FirstName, LastName, Email, Address, PhoneNumber, Password, Company_Id)
	       VALUES (@FirstName, @LastName, @Email, @Address, @PhoneNumber, @Password, @Company_Id)

END
GO


CREATE PROCEDURE stpInsertCompany
   -- Adding the parameters for the stored procedure
   @Name nvarchar(70),
   @Description varchar (250),
   @Address varchar (200),
   @PhoneNumber varchar(20)

AS
BEGIN

	-- Insert statements for procedure 
	INSERT INTO Company(Name, Description, Address, PhoneNumber)
	       VALUES (@Name, @Description, @Address, @PhoneNumber)

END
GO

--Defining the Update Stored Procedure

CREATE PROCEDURE stpUpdateUserById
	-- Adding the parameters for the stored procedure
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(30),
	@Email varchar(20),
	@Address varchar(200),
	@PhoneNumber varchar(20),
	@Password varchar(20),
	@Company_Id int
	
AS
BEGIN

    -- Update statements for procedure 
    UPDATE User
	Set @FirstName = @FirstName,
	    LastName = @LastName,
		Email = @Email,
		Address = @Address,
		PhoneNumber = @PhoneNumber,
		Password = @Password,
		@Company_Id = @Company_Id
	WHERE Id = @Id

END
GO

--Defining the Delete Stored Procedure

CREATE PROCEDURE stpDeleteCompanyById
   -- Adding the parameters for the stored procedure
   @Id int

AS
BEGIN
  
    -- Delete statements for procedure 
    DELETE FROM Company
	WHERE Id = @Id

END
GO


--Executing All Defined Stored Procedures

--Execute stpInsertCompany Procedure
DECLARE @return_company int

EXEC @return_company = [dbo].[stpInsertCompany]
     @Name = 'Logo Yazılım',
	 @Description = 'https://www.logo.com.tr/logo-hakkinda',
	 @Address = 'İzmir, Turkey',
	 @PhoneNumber = '444 56 46'

SELECT 'Return Company' = @return_company
GO


DECLARE @return_company int

EXEC @return_company = [dbo].[stpInsertCompany]
     @Name = 'Patika.dev',
	 @Description = 'https://www.patika.dev/tr/hakkimizda',
	 @Address = 'Turkey',
	 @PhoneNumber = 'xxx xx xx'

SELECT 'Return Company' = @return_company
GO


--Execute stpInsertUser Procedure
DECLARE @return_user int

EXEC    @return_user = [dbo].[stpInsertUser]
        @FirstName = 'Meleknur',
		@LastName = 'Yazlamaz',
		@Email = 'meleknuryazlamaz@gmail.com',
		@Address ='Mersin, Turkey',
		@PhoneNumber = '+90001234567',
		@Password = '1234',
		@Company_Id = 1

SELECT 'Return User' = @return_user
GO


--Execute  stpUpdateUserById Procedure
DECLARE @return_updated_user int

EXEC    @return_updated_user = [dbo].[stpUpdateUserById]
        @Id = 1,
        @FirstName = 'Meleknur',
		@LastName = 'Yazlamaz',
		@Email = 'melek@gmail.com',
		@Address ='Mersin, Turkey',
		@PhoneNumber = '+90001234567',
		@Password = '4567',           --Password updated
		@Company_Id = 1

SELECT 'Return Updated User' = @return_updated_user
GO


--Execute  stpDeleteCompanyById Procedure
EXEC stpDeleteCompanyById 2


--Checking Tables
SELECT * FROM User
Select * FROM Company
SELECT FirstName, LastName FROM User INNER JOIN Company ON User.Company_Id = Company.Id
SELECT Password FROM User