
/* insert User Data */

INSERT INTO [dbo].[User] Values('Test','User1','TestUser1','password1','test@abc.com')
INSERT INTO [dbo].[User] Values('Test','User2','TestUser2','password1','test@abc.com')
INSERT INTO [dbo].[User] Values('Test','User3','TestUser3','password1','test@abc.com')
INSERT INTO [dbo].[User] Values('Test','User4','TestUser4','password1','test@abc.com')
INSERT INTO [dbo].[User] Values('Test','User5','TestUser5','password1','test@abc.com')

GO
/* insert Movie Data */
INSERT INTO Movie values('The Shawshank Redemption',1994,142,'Drama')
INSERT INTO Movie values('The Godfather',1972,202,'Crime,Drama')
INSERT INTO Movie values('The Dark Knight',1974,152,'Action,Crime,Drama')
INSERT INTO Movie values('Pulp Fictions',1993,195,'Biography, Drama, History')
INSERT INTO Movie values('12 Angry Men',1996,96,'Drama')
INSERT INTO Movie values('Inception',2010,148,'Action, Adventure, Sci-Fi')
INSERT INTO Movie values('Fight Club',199,139,'Drama')
INSERT INTO Movie values('The Matrix',199,136,'Action, Sci-Fi')
INSERT INTO Movie values('Goodfellas',199,146,'Crime, Drama')
GO

/* insert data into Rating */


Declare @UserID int;
Declare @MovieID int;
declare @random int;
DECLARE User_Cursor CURSOR FOR  
SELECT UserID
FROM [dbo].[User] 
OPEN User_Cursor;  
FETCH NEXT FROM User_Cursor into @UserID;  
WHILE @@FETCH_STATUS = 0  
BEGIN  
	  PRINT 'Processing UserID: ' + Cast(@UserID as Varchar);
	  DECLARE Movie_Cursor CURSOR FOR
        SELECT MovieID FROM Movie ;
		OPEN Movie_Cursor;
		FETCH NEXT FROM Movie_Cursor INTO @MovieID;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'Found UID: ' + Cast(@MovieID as Varchar);
			
			INSERT INTO Rating values(@MovieID,@UserID,ROUND( RAND()*(5-3)+3,2))
			FETCH NEXT FROM Movie_Cursor INTO @MovieID;
		END; 
	CLOSE Movie_Cursor;
    DEALLOCATE Movie_Cursor;
    FETCH NEXT FROM User_Cursor INTO @UserID;
END;
PRINT 'DONE';
CLOSE User_Cursor;
DEALLOCATE User_Cursor;
GO