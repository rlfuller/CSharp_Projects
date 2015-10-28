USE DVDLibrary
GO

 DECLARE @mostRecentDVDID int
  EXEC @mostRecentDVDID =
 SP_AddDVD
@Title = 'Elf', @ReleaseDate = '11-07-2003', @MPAA = 'PG', @Director = 'Jon Favreau', @StudioID = 3;



 --Will farrell
 EXEC SP_AddDVDActorDetails
 @DVDID =  @mostRecentDVDID, @ActorID = 2;
 GO