INSERT INTO Campus(city) VALUES ('Strasbourg'),('Paris'),('Lyon')
GO

INSERT INTO Cursus([name],startTime,endTime) VALUES
('c#','20191209','20200507'),
('php','20200302','20200805')
GO

INSERT INTO Expedition([name],startTime,endTime,FK_cursus_id) VALUES
('Premi�re expedition', '20191210', '20191218',1),
('Seconde expedition', '20191210', '20191218',1),
('Premi�re expedition', '20200303', '20200311',2),
('Seconde expedition', '20200303', '20200311',2)
GO

INSERT INTO Quest([name],[text],FK_expedition_id) VALUES
('C# Niveau 1','Level up',1),
('C# Niveau 2','Level up',1),
('C# Niveau 3','Level up',2),
('C# Niveau 4','Level up',2),
('PHP Niveau 1','Level up',3),
('PHP Niveau 2','Level up',3),
('PHP Niveau 3','Level up',4),
('PHP Niveau 4','Level up',4)
GO

INSERT INTO CampusCursus(FK_campus_id,FK_cursus_id) VALUES
(1,1),
(1,2),
(2,2),
(3,2)
GO

INSERT INTO Agenda(title,startTime,endTime,[description]) VALUES
('Rentr�e C#','20191209','20191209','Acceuil'),
('Rentr�e PHP','20200302','20200302','Acceuil'),
('Checkpoint 1 C#', '20190115','20190115','Checkpoint')
GO

INSERT INTO CalendarCursus(FK_cursus_id,FK_event_id) VALUES
(1,1),
(2,2),
(1,3)
GO

INSERT INTO Person([name],[type],FK_cc_id,FK_superior_id) VALUES
('Nathaniel', 'student', 1, 3),
('Claire', 'student', 1, 3),
('Instructor1','instructor',1,4),
('Chef1','leadInstructor',1,4),
('Sam','student',2,7),
('Dean','student',2,7),
('Bobby','instructor',2,4)
GO

INSERT INTO AgendaPerson(FK_id,FK_event_id) VALUES
(1,1),
(1,3),
(2,1),
(2,3),
(3,1),
(4,1),
(4,2),
(5,2),
(6,2),
(7,2)
GO





