

USE [DVDLibrary]
GO

---- This will delete any current data in the database and reset the keys to start at 1 ---


DELETE FROM Actors;
DBCC CHECKIDENT ('[Actors]', RESEED, 0)
GO

DELETE FROM Borrowers;
DBCC CHECKIDENT ('[Borrowers]', RESEED, 0)
GO

DELETE FROM DVDActorDetails;

DELETE FROM DVDBorrowerDetails;

DELETE FROM DVDs;
DBCC CHECKIDENT ('[DVDs]', RESEED, 0)
GO

DELETE FROM MPAA;

DELETE FROM Studios;
DBCC CHECKIDENT ('[Studios]', RESEED, 0)
GO

DELETE FROM UserNotesDVDDetails;
DBCC CHECKIDENT ('[UserNotesDVDDetails]', RESEED, 0)
GO

DELETE FROM Users;
DBCC CHECKIDENT ('[Users]', RESEED, 0)
GO


---All the reference tables ----

INSERT INTO MPAA (MPAA, MPAADescription)
VALUES ('G','General Audiences'),
		('PG','Parental Guidance Suggested'),
		('PG-13','Parents Strongly Cautioned'),
		('R','Restricted'),
		('NC-17','Adults Only'),
		('NR','Not Rated')

INSERT INTO Actors (ActorName)
VALUES	('Not listed'),
		('Will Ferrell'),
	    ('John C. Reilly'),
		('Elijah Wood'),
		('Ian McKellen'),
		('Orlando Bloom'),
		('Ryan Reynolds'),
		('Amy Smart'),
		('Bruce Willis'),
		('Milla Jovovich'), --10
		('Richard Dreyfuss'),
		('Glenne Headly'),
		('Andy Samberg'),
		('Isla Fisher'),
		('Ryan Gosling'),
		('Rachel McAdams'),
		('Tim Allen'),
		('Tom Hanks')


INSERT INTO Studios (StudioName)
VALUES ('Not listed'),
		('Columbia Pictures'),
		('New Line Cinema'),
		('Gaumont'),
		('Hollywood Pictures'),
		('Paramount Pictures'),
		('Pixar')
		

INSERT INTO Borrowers (BorrowerName)
VALUES ('Paul'),
		('Amanda'),
		('Andy'),
		('Rachel'),
		('Dave'),
		('Randall')

INSERT INTO Users (UserName)
VALUES ('Paul'),
		('Amanda'),
		('Andy'),
		('Rachel'),
		('Dave'),
		('Randall'),
		('Jim'),
		('Ringo'),
		('Matteo'),
		('Heather');

----- Begin with the individual DVDs ----

----- Talledega Nights -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('Talledega Nights', '09-04-2006', 'PG-13', 'Adam McKay', 2);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (1,2),
	   (1,3);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (1,1, '10-15-2015', null),
		(1, 2, '07-10-2008', '07-17-2008')

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (1, 1, 4, null),
		(1, 2, 4, 'Shake and Bake'),
		(1, 5,  4, 'If you''re not first you''re last')


----- Lotr -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('Lord of the Rings: The Fellowship of the Ring', '12-19-2001', 'PG-13', 'Peter Jackson', 3);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (2,4),
	   (2,5),
	   (2,6);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (2,4, '10-15-2002', null);

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (2, 4, 5, null),
		(2, 1, 5, 'Awesome.'),
		(2, 1,  5, 'Seriously, Awesome.')

		----- Just Friends -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('JustFriends', '11-23-2005', 'PG-13', 'Roger Kumble', 3);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (3,7),
	   (3,8);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (3,3, '10-23-2009', '11-23-2009'),
		(3, 2, '09-10-2011', '09-17-2011'),
		(3,3, '08-25-2012', '09-03-2012');

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (3, 3, 5, 'Ryan Reynolds is dreamy');

----- The Fifth Element -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('The Fifth Element', '05-09-1997', 'PG-13', 'Luc Besson', 4);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (4,9),
	   (4,10);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (4,5, '04-22-2001', '04-24-2001'),
		(4, 6, '03-10-2008', '04-17-2008'),
		(4, 1, '11-20-2010', '11-28-2010'),
		(4, 2, '10-20-2015', null);

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (4, 5, 4, null),
		(4, 6, 4, 'I want to be Korben Dallas.'),
		(4, 2,  4, 'Idk, Paul made me watch it.'),
		(4, 10, 5, 'Those were the days when Bruce Willis had hair.');

		----- Mr. Holland's Opus -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('Mr. Holland''s Opus', '01-19-1996', 'PG', 'Stephen Herek', 5);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (5,11),
	   (5,12);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (5,3, '04-22-2001', '04-24-2001'),
		(5, 4, '03-10-2009', '04-17-2009');


----- Hot Rod -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('Hot Rod', '08-03-2007', 'PG-13', 'Akiva Schaffer', 6);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (6,13),
	   (6,14);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (6,4, '04-22-2008', '04-24-2008'),
		(6, 6, '12-10-2008', '12-17-2008'),
		(6, 2, '01-20-2010', '01-28-2010');

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (6, 2, 3, 'Cool Beans'),
		(6, 1, 1, 'I gouged my eyes out.');


----- The Notebook -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('The Notebook', '06-25-2004', 'PG-13', 'Nick Cassavetes', 3);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (7,15),
	   (7,16);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (7,6, '01-22-2005', '02-08-2005'),
		(7, 6, '02-10-2005', '02-17-2005'),
		(7, 6, '04-20-2005', '04-28-2005'),
		(7,6, '05-05-2005', '05-14-2005'),
        (7,6, '06-22-2005', '07-08-2005'),
		(7, 6, '08-03-2005', '08-17-2005'),
		(7, 6, '09-11-2005', '09-18-2005'),
		(7,6, '10-05-2005', '10-14-2005'),
		(7,6, '10-15-2005', '10-20-2005'),
		(7, 6, '10-21-2005', '10-31-2005'),
		(7,6, '11-15-2005', '11-20-2005'),
		(7, 6, '11-21-2005', '11-22-2005'),
		(7,6, '12-15-2005', '12-20-2005'),
		(7, 6, '12-21-2005', '12-31-2005'),
		(7,6, '01-22-2005', '02-08-2005'),
		(7, 6, '02-10-2005', '02-17-2005'),
		(7, 6, '04-20-2005', '04-28-2005'),
		(7,6, '05-05-2005', '05-14-2005'),
        (7,6, '06-22-2005', '07-08-2005'),
		(7, 6, '08-03-2005', '08-17-2005'),
		(7, 6, '09-11-2005', '09-18-2005'),
		(7,6, '10-05-2005', '10-14-2005'),
		(7,6, '10-15-2005', '10-20-2005'),
		(7, 6, '10-21-2005', '10-31-2005'),
		(7,6, '11-15-2005', '11-20-2005'),
		(7, 6, '11-21-2005', '11-22-2005'),
		(7,6, '12-15-2005', '12-20-2005'),
		(7, 6, '12-21-2005', '12-31-2005'),
		(7,6, '01-22-2006', '02-08-2006'),
		(7, 6, '02-10-2006', '02-17-2006'),
		(7, 6, '04-20-2006', '04-28-2006'),
		(7,6, '05-05-2006', '05-14-2006'),
        (7,6, '06-22-2006', '07-08-2006'),
		(7, 6, '08-03-2006', '08-17-2006'),
		(7, 6, '09-11-2006', '09-18-2006'),
		(7,6, '10-05-2006', '10-14-2006'),
		(7,6, '10-15-2006', '10-20-2006'),
		(7, 6, '10-21-2006', '10-31-2006'),
		(7,6, '11-15-2006', '11-20-2006'),
		(7, 6, '11-21-2006', '11-22-2006'),
		(7,6, '12-15-2006', '12-20-2006'),
		(7, 6, '12-21-2006', '12-31-2006'),
		(7,6, '01-22-2007', '02-08-2007'),
		(7, 6, '02-10-2007', '02-17-2007'),
		(7, 6, '04-20-2007', '04-28-2007'),
		(7,6, '05-05-2007', '05-14-2007'),
        (7,6, '06-22-2007', '07-08-2007'),
		(7, 6, '08-03-2007', '08-17-2007'),
		(7, 6, '09-11-2007', '09-18-2007'),
		(7,6, '10-05-2007', '10-14-2007'),
		(7,6, '10-15-2007', '10-20-2007'),
		(7, 6, '10-21-2007', '10-31-2007'),
		(7,6, '11-15-2007', '11-20-2007'),
		(7, 6, '11-21-2007', '11-22-2007'),
		(7,6, '12-15-2007', '12-20-2007'),
		(7, 6, '12-21-2007', null);



INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (7, 6, 5, 'No matter what happens to us, everyday spent with you is the best day of my life'),
		(7, 1, 5, 'Why won''t Ryan Gosling eat his cereal??');

		----- Toy Story -------


INSERT INTO DVDs (Title, ReleaseDate, MPAA, Director, StudioID)
VALUES ('Toy Story', '11-22-1995', 'G', 'John Lasseter', 7);


INSERT INTO DVDActorDetails (DVDID, ActorID)
VALUES (8,17),
	   (8,18);

INSERT INTO DVDBorrowerDetails(DVDID, BorrowerID, DateBorrowed, DateReturned)
VALUES (8,5, '10-22-2001', '10-24-2001'),
		(8, 4, '03-14-2005', '04-17-2005'),
		(4, 1, '05-20-2010', '05-28-2010');

INSERT INTO UserNotesDVDDetails (DVDID, UserID, Rating, UserNotesDescription)
VALUES (8, 8, 5, 'I give it a 4.9');