USE DVDLibrary
GO


--Add the DVD
CREATE PROCEDURE SP_AddDVD
(
 @Title varchar(140),
 @ReleaseDate date,
 @MPAA varchar(10),
 @Director varchar(90),
 @StudioID int,
 @DVDID int output
) AS

INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES (@Title, @ReleaseDate, @MPAA, @Director, @StudioID);

SET @DVDID = SCOPE_IDENTITY();

GO


-- You'll have to call this for each actor
CREATE PROCEDURE SP_AddDVDActorDetails
(
 @DVDID int,
 @ActorID int
) AS

INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (@DVDID,@ActorID);
GO