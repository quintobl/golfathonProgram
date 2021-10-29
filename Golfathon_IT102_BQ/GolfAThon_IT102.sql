-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes


-- --------------------------------------------------------------------------------------------------------
-- Drop procedure statements
-- --------------------------------------------------------------------------------------------------------
IF OBJECT_ID('uspAddGolfer')									IS NOT NULL DROP PROCEDURE  uspAddGolfer
IF OBJECT_ID('uspAddEvent')										IS NOT NULL DROP PROCEDURE  uspAddEvent
IF OBJECT_ID('uspAddGolferEvent')								IS NOT NULL DROP PROCEDURE  uspAddGolferEvent
IF OBJECT_ID('uspDeleteSponsor')								IS NOT NULL DROP PROCEDURE  uspDeleteSponsor
IF OBJECT_ID('uspDeleteGolferEventYearSponsor')					IS NOT NULL DROP PROCEDURE  uspDeleteGolferEventYearSponsor
IF OBJECT_ID('uspDeleteGolferEventYearSponsorAndSponsor')		IS NOT NULL DROP PROCEDURE  uspDeleteGolferEventYearSponsorAndSponsor
IF OBJECT_ID('uspUpdateSponsor')								IS NOT NULL DROP PROCEDURE  uspUpdateSponsor
IF OBJECT_ID('uspAddSponsor')									IS NOT NULL DROP PROCEDURE  uspAddSponsor
IF OBJECT_ID('uspAddSponsorToGolfer')							IS NOT NULL DROP PROCEDURE  uspAddSponsorToGolfer


-- --------------------------------------------------------------------------------------------------------
-- Drop Views
-- --------------------------------------------------------------------------------------------------------
IF OBJECT_ID('vAvailableGolfers')				IS NOT NULL DROP VIEW		vAvailableGolfers
IF OBJECT_ID('vGolferEvents')					IS NOT NULL DROP VIEW		vGolferEvents
IF OBJECT_ID('vAvailableSponsors')				IS NOT NULL DROP VIEW		vAvailableSponsors
IF OBJECT_ID('vGolferSponsors')					IS NOT NULL DROP VIEW		vGolferSponsors
IF OBJECT_ID('vTotalEventDonations')			IS NOT NULL DROP VIEW		vTotalEventDonations
IF OBJECT_ID('vGolferEventTotals')				IS NOT NULL DROP VIEW		vGolferEventTotals
IF OBJECT_ID('vSponsorEventTotals')				IS NOT NULL DROP VIEW		vSponsorEventTotals



-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER		NOT NULL
	,intGolferID			INTEGER			NOT NULL
	,intEventYearID			INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER			NOT NULL
	,intGolferID					INTEGER			NOT NULL
	,intEventYearID					INTEGER			NOT NULL
	,intSponsorID					INTEGER			NOT NULL
	,monPledgeAmount				DECIMAL			NOT NULL
	,intSponsorTypeID				INTEGER			NOT NULL
	,intPaymentTypeID				INTEGER			NOT NULL
	,blnPaid						INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )
ON DELETE CASCADE

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )
ON DELETE CASCADE

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )
ON DELETE CASCADE

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )
ON DELETE CASCADE

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )
ON DELETE CASCADE

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )
ON DELETE CASCADE

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )
ON DELETE CASCADE

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )
ON DELETE CASCADE

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2018)
		,( 2, 2019)
		,(3, 2020)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (1, 1, 1)
		,(2, 2, 1)
		,(3, 1, 2)
		,(4, 2, 2)

---- --------------------------------------------------------------------------------
---- Step # 11: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
		,( 2, 1, 1, 2, 25.00, 1, 1, 1 )


	
-- --------------------------------------------------------------------------------
-- Step #12: Create a stored procedure to add a golfer - uspAddGolfer
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddGolfer
	 @intGolferID AS INTEGER OUTPUT
	,@strFirstName AS VARCHAR(50)
	,@strLastName AS VARCHAR(50)
	,@strStreetAddress AS VARCHAR(50)
	,@strCity AS VARCHAR(50)
	,@strState AS VARCHAR(50)
	,@strZip AS VARCHAR(50)
	,@strPhoneNumber AS VARCHAR(50)
	,@strEmail AS VARCHAR(50)
	,@intShirtSizeID AS INTEGER
	,@intGenderID AS INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intGolferID = MAX(intGolferID) + 1 
	FROM TGolfers (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	INSERT INTO TGolfers (intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, 
							strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
	VALUES				(@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, 
							@strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--DECLARE @intGolferID AS INTEGER = 0
--EXECUTE uspAddGolfer @intGolferID OUTPUT, 'Kilgore', 'Trout', '123 Main St.', 'Cincinnati', 'OH', '45210', '5132291111', 'ktrout@aol.com', 4, 2
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR, @intGolferID)



-- --------------------------------------------------------------------------------
-- Step #13: Create a stored procedure to add an event - uspAddEvent
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddEvent
	 @intEventYearID AS INTEGER OUTPUT
	,@intEventYear AS INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intEventYearID = MAX(intEventYearID) + 1 
	FROM TEventYears (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)

	INSERT INTO TEventYears (intEventYearID, intEventYear) 
	VALUES				(@intEventYearID, @intEventYear)


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--DECLARE @intEventYearID AS INTEGER = 0
--EXECUTE uspAddEvent @intEventYearID OUTPUT, 2001
--PRINT 'Event ID = ' + CONVERT(VARCHAR, @intEventYearID)



-- -----------------------------------------------------------------------------------------
-- Step #14: Create a stored procedure to add a golfer to an event - uspAddGolferEvent
-- -----------------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddGolferEvent
	 @intGolferEventYearID		AS INTEGER OUTPUT
	,@intGolferID				AS INTEGER
	,@intEventYearID			AS INTEGER
AS
SET NOCOUNT ON --report only errors
SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intGolferEventYearID = MAX(intGolferEventYearID) + 1 
	FROM TGolferEventYears (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intGolferEventYearID = COALESCE(@intGolferEventYearID, 1)

	INSERT INTO TGolferEventYears WITH (TABLOCKX) (intGolferEventYearID, intGolferID, intEventYearID) 
	VALUES				(@intGolferEventYearID, @intGolferID, @intEventYearID)


COMMIT TRANSACTION

GO



--DECLARE @intGolferEventYearID AS INTEGER = 0
--EXECUTE uspAddGolferEventYears @intGolferEventYearID OUTPUT, 3, 4
--PRINT 'Golfer Event ID = ' + CONVERT(VARCHAR, @intGolferEventYearID)


--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TGolferEventYears




-- -----------------------------------------------------------------------------------------
-- Step #15: Create a stored procedure to delete a sponsor - uspDeleteSponsor
-- -----------------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspDeleteSponsor
	  @intSponsorID		AS INTEGER OUTPUT

AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	DELETE FROM TSponsors WHERE intSponsorID = @intSponsorID

COMMIT TRANSACTION

GO

DECLARE @intSponsorID	AS INTEGER = 0
EXECUTE uspDeleteSponsor @intSponsorID OUTPUT



--DECLARE @intSponsorID AS INTEGER = 0
--EXECUTE uspDeleteSponsor @intSponsorID OUTPUT
--PRINT 'Sponsor Event ID = ' + CONVERT(VARCHAR, @intSponsorID)


--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TGolferEventYears



-- ----------------------------------------------------------------------------------------------------------------------
-- Step #16: Create a stored procedure to delete sponsor from TGolferEventYearSponsors - uspDeleteGolferEventYearSponsor
-- ----------------------------------------------------------------------------------------------------------------------


GO

CREATE PROCEDURE uspDeleteGolferEventYearSponsor
	 @intGolferEventYearSponsorID AS INTEGER OUTPUT

AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	DELETE FROM TGolferEventYearSponsors WHERE intGolferEventYearSponsorID = @intGolferEventYearSponsorID

COMMIT TRANSACTION

GO


--DECLARE @intGolferEventYearSponsorID AS INTEGER = 0
--EXECUTE uspDeleteGolferEventYearSponsor @intGolferEventYearSponsorID OUTPUT



-- ----------------------------------------------------------------------------------------------------------------------
-- Step #17: Create a stored procedure to update sponsor info - uspUpdateSponsor
-- ----------------------------------------------------------------------------------------------------------------------


GO

CREATE PROCEDURE uspUpdateSponsor
	 @intSponsorID AS INTEGER OUTPUT
	,@strFirstName AS VARCHAR(50)
	,@strLastName AS VARCHAR(50)
	,@strStreetAddress AS VARCHAR(50)
	,@strCity AS VARCHAR(50)
	,@strState AS VARCHAR(50)
	,@strZip AS VARCHAR(50)
	,@strPhoneNumber AS VARCHAR(50)
	,@strEmail AS VARCHAR(50)

AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION


	UPDATE TSponsors SET intSponsorID = @intSponsorID 
						,strFirstName = @strFirstName
						,strLastName = @strLastName
						,strStreetAddress = @strStreetAddress
						,strCity = @strCity
						,strState = @strState
						,strZip = @strZip
						,strPhoneNumber = @strPhoneNumber
						,strEmail = @strEmail
	WHERE intSponsorID = @intSponsorID
		   
COMMIT TRANSACTION

GO


--DECLARE @intSponsorID AS INTEGER = 0
--EXECUTE uspUpdateSponsor 1, 'Ted', 'Payne', '510 Main', 'Cincinnati', 'OH', '45202', '5138889999', 'tpayne@aol.com'




-- ----------------------------------------------------------------------------------------------------------------------
-- Step #18: Create a stored procedure to add a sponsor - uspAddSponsor
-- ----------------------------------------------------------------------------------------------------------------------


GO

CREATE PROCEDURE uspAddSponsor
	 @intSponsorID AS INTEGER OUTPUT
	,@strFirstName AS VARCHAR(50)
	,@strLastName AS VARCHAR(50)
	,@strStreetAddress AS VARCHAR(50)
	,@strCity AS VARCHAR(50)
	,@strState AS VARCHAR(50)
	,@strZip AS VARCHAR(50)
	,@strPhoneNumber AS VARCHAR(50)
	,@strEmail AS VARCHAR(50)

AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intSponsorID = MAX(intSponsorID) + 1 
	FROM TSponsors (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intSponsorID = COALESCE(@intSponsorID, 1)

	INSERT INTO TSponsors (intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)
	VALUES				(@intSponsorID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail)


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--DECLARE @intSponsorID AS INTEGER = 0
--EXECUTE uspAddSponsor @intSponsorID OUTPUT, 'Billy', 'Pilgrim', '821 Devine St.', 'Cincinnati', 'OH', '45202', '5138192929', 'bpilgrim@aol.com'
--PRINT 'Sponsor ID = ' + CONVERT(VARCHAR, @intSponsorID)




-- ----------------------------------------------------------------------------------------------------------------------
-- Step #19: Create a view to show available golfers - vAvailableGolfers
-- ----------------------------------------------------------------------------------------------------------------------


GO
	
CREATE VIEW vAvailableGolfers
AS
SELECT
	 TGolfers.intGolferID
	,TGolfers.strLastName
FROM
	TGolfers

WHERE intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears WHERE intEventYearID IN (SELECT MAX(intEventYearID) FROM TEventYears))




GO

SELECT * FROM vAvailableGolfers




-- ----------------------------------------------------------------------------------------------------------------------
-- Step #20: Create a view to show events and the golfers tied to them - vGolferEvents
-- ----------------------------------------------------------------------------------------------------------------------


GO

CREATE VIEW vGolferEvents
AS
SELECT
	 TGolfers.intGolferID
	,TGolfers.strLastName
	,TEventYears.intEventYearID
FROM
	TGolferEventYears
		JOIN TEventYears
			ON TGolferEventYears.intEventYearID = TEventYears.intEventYearID
		JOIN TGolfers
			ON TGolferEventYears.intGolferID = TGolfers.intGolferID	


GO

SELECT * FROM vGolferEvents



-- ----------------------------------------------------------------------------------------------------------------------
-- Step #21: Create a view to connect golfers with sponsors- vGolferSponsors
-- ----------------------------------------------------------------------------------------------------------------------


GO

CREATE VIEW vGolferSponsors
AS
SELECT
	 TSponsors.intSponsorID
	,TSponsors.strLastName
	,TGolfers.intGolferID
FROM
	TSponsors
		JOIN TGolferEventYearSponsors
			ON TSponsors.intSponsorID = TGolferEventYearSponsors.intSponsorID
		JOIN TGolfers
			ON TGolfers.intGolferID = TGolferEventYearSponsors.intGolferID


GO

SELECT * FROM vGolferSponsors
		



-- ----------------------------------------------------------------------------------------------------------------------
-- Step #22: Create a view for available sponsors - vAvailableSponsors
-- ----------------------------------------------------------------------------------------------------------------------

GO

CREATE VIEW vAvailableSponsors
AS
SELECT
	 TSponsors.intSponsorID
	,TSponsors.strLastName
	,TGolfers.intGolferID
FROM
	TSponsors
		LEFT JOIN TGolferEventYearSponsors
			ON TSponsors.intSponsorID = TGolferEventYearSponsors.intSponsorID
		LEFT JOIN TGolfers
			ON TGolfers.intGolferID = TGolferEventYearSponsors.intGolferID

GO

SELECT * FROM vAvailableSponsors



-- -----------------------------------------------------------------------------------------
-- Step #23: Create a stored procedure to add a sponsor to a golfer - uspAddSponsorToGolfer
-- -----------------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddSponsorToGolfer
	 @intGolferEventYearSponsorID		AS INTEGER OUTPUT
	,@intGolferID						AS INTEGER
	,@intEventYearID					AS INTEGER
	,@intSponsorID						AS INTEGER
	,@monPledgeAmount					AS DECIMAL
	,@intSponsorTypeID					AS INTEGER
	,@intPaymentTypeID					AS INTEGER
	,@blnPaid							AS INTEGER

AS
SET NOCOUNT ON --report only errors
SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intGolferEventYearSponsorID = MAX(intGolferEventYearSponsorID) + 1 
	FROM TGolferEventYearSponsors (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intGolferEventYearSponsorID = COALESCE(@intGolferEventYearSponsorID, 1)

	INSERT INTO TGolferEventYearSponsors WITH (TABLOCKX) (intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, 
															monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid) 
	VALUES				(@intGolferEventYearSponsorID, @intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, 
							@intSponsorTypeID, @intPaymentTypeID, @blnPaid )


COMMIT TRANSACTION

GO



-- -----------------------------------------------------------------------------------------
-- Step #24: Create a view to see total event donation totals - vTotalEventDonations
-- -----------------------------------------------------------------------------------------

GO

CREATE VIEW vTotalEventDonations
AS
SELECT   TGolferEventYearSponsors.intEventYearID
		,SUM (TGolferEventYearSponsors.monPledgeAmount) AS SUM
FROM TGolferEventYearSponsors

GROUP BY TGolferEventYearSponsors.intEventYearID


GO

SELECT * FROM vTotalEventDonations





-- -----------------------------------------------------------------------------------------
-- Step #25: Create a view to see golfer donations by event - vGolferEventTotals
-- -----------------------------------------------------------------------------------------

GO


CREATE VIEW vGolferEventTotals
AS
SELECT   TGolferEventYearSponsors.intEventYearID
		,TGolferEventYearSponsors.intGolferID
		,SUM (TGolferEventYearSponsors.monPledgeAmount) AS SUM

FROM TGolferEventYearSponsors

GROUP BY TGolferEventYearSponsors.intEventYearID, TGolferEventYearSponsors.intGolferID


GO


SELECT * FROM vGolferEventTotals




-- -----------------------------------------------------------------------------------------
-- Step #26: Create a view to see sponsor donations by event - vSponsorEventTotals
-- -----------------------------------------------------------------------------------------

GO


CREATE VIEW vSponsorEventTotals
AS
SELECT   TGolferEventYearSponsors.intEventYearID
		,TGolferEventYearSponsors.intSponsorID
		,SUM (TGolferEventYearSponsors.monPledgeAmount) AS SUM

FROM TGolferEventYearSponsors

GROUP BY TGolferEventYearSponsors.intEventYearID, TGolferEventYearSponsors.intSponsorID


GO


SELECT * FROM vSponsorEventTotals