IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[GetAllCandidates]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[GetAllCandidates]
END
GO

CREATE PROCEDURE [GetAllCandidates]
AS
BEGIN
SELECT [ID]
      ,[FirstName]
      ,[Surname]
      ,[DateOfBirth]
      ,[Address1]
      ,[Town]
      ,[Country]
      ,[PostCode]
      ,[PhoneHome]
      ,[PhoneMobile]
      ,[PhoneWork]
  FROM [Web_API_Task].[dbo].[Candidate]
END
GO

IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[GetCandidate]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[GetCandidate]
END
GO

CREATE PROCEDURE [GetCandidate]
@ID AS INTEGER
AS
BEGIN
SELECT [ID]
      ,[FirstName]
      ,[Surname]
      ,[DateOfBirth]
      ,[Address1]
      ,[Town]
      ,[Country]
      ,[PostCode]
      ,[PhoneHome]
      ,[PhoneMobile]
      ,[PhoneWork]
  FROM [Web_API_Task].[dbo].[Candidate]
  WHERE [ID] = @ID
END
GO

IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[AddCandidate]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[AddCandidate]
END
GO
CREATE PROCEDURE [AddCandidate]
@ID AS INTEGER,
@Forename AS VARCHAR(50),
@Surname AS VARCHAR(50),
@DOB AS DATE,
@Address AS VARCHAR(100),
@Town AS VARCHAR(50),
@Country AS VARCHAR(50),
@PostCode AS VARCHAR(20),
@PHome AS VARCHAR(50),
@PMobile AS VARCHAR(50),
@PWork AS VARCHAR(50)
AS
BEGIN
INSERT INTO [Web_API_Task].[dbo].[Candidate]
	   ([ID]
	  ,[FirstName]
      ,[Surname]
      ,[DateOfBirth]
      ,[Address1]
      ,[Town]
      ,[Country]
      ,[PostCode]
      ,[PhoneHome]
      ,[PhoneMobile]
      ,[PhoneWork],
	  [UpdatedDate],
	  [CreatedDate])
  VALUES
  (@ID,
  @Forename,
  @Surname,
  @DOB,
  @Address,
  @Town,
  @Country,
  @PostCode,
  @PHome,
  @PMobile,
  @PWork,
  GETUTCDATE(),
  GETUTCDATE())
END
GO

IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[DeleteCandidate]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[DeleteCandidate]
END
GO
CREATE PROCEDURE [DeleteCandidate]
@ID as INTEGER
AS
BEGIN
DELETE FROM CandidateSkill
WHERE CandidateID = @ID

DELETE FROM Candidate
WHERE ID = @ID

END
GO

IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCandidate]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[UpdateCandidate]
END
GO
CREATE PROCEDURE [UpdateCandidate]
@ID AS INTEGER,
@Forename AS VARCHAR(50),
@Surname AS VARCHAR(50),
@DOB AS DATE,
@Address AS VARCHAR(100),
@Town AS VARCHAR(50),
@Country AS VARCHAR(50),
@PostCode AS VARCHAR(20),
@PHome AS VARCHAR(50),
@PMobile AS VARCHAR(50),
@PWork AS VARCHAR(50)
AS
BEGIN
UPDATE Candidate
SET
	[FirstName] = @Forename
    ,[Surname] = @Surname
    ,[DateOfBirth] = @DOB
    ,[Address1] = @Address
    ,[Town] = @Town
    ,[Country] = @Country
    ,[PostCode] = @PostCode
    ,[PhoneHome] = @PHome
    ,[PhoneMobile] = @PMobile
    ,[PhoneWork] = @PWork
	,[UpdatedDate] = GETUTCDATE()
WHERE ID = @ID
END
GO

IF EXISTS (SELECT * FROM sys.objects 
           WHERE object_id = OBJECT_ID(N'[dbo].[GetCandidateId]') 
           AND type in (N'P', N'PC')) 
BEGIN
    DROP PROCEDURE [dbo].[GetCandidateId]
END
GO
CREATE PROCEDURE [GetCandidateId]
AS
BEGIN
SELECT TOP 1 Id 
From dbo.Candidate
order by ID Desc
END
GO