USE Checkpoint2_bc;



--Grouper les quêtes par exepdition

SELECT COUNT(Quest.[name]), Expedition.[name], Cursus.[name]
FROM Quest
INNER JOIN Expedition ON Expedition.expedition_id=Quest.FK_expedition_id
INNER JOIN Cursus ON Cursus.cursus_id=Expedition.FK_cursus_id
GROUP BY Expedition.[name], Cursus.[name]

--Requête Procédure stockée

--afficher tous les étudiants d'un cursus

DROP PROCEDURE IF EXISTS sp_GetStudentsByCursus
﻿GO

CREATE PROCEDURE sp_GetStudentsByCursus
   @CursusName VARCHAR(20)
   AS
   BEGIN
    SELECT Person.[name] AS StudentsName
	FROM Person
	INNER JOIN CampusCursus ON CampusCursus.id=Person.FK_cc_id
	INNER JOIN Cursus ON Cursus.cursus_id=CampusCursus.FK_cursus_id
	WHERE [type] = 'student' AND Cursus.[name]=@CursusName
   END
GO

DECLARE @StudentsInCursus INT
EXECUTE @StudentsInCursus  = sp_GetStudentsByCursus 'c#'
PRINT @StudentsInCursus
GO



--afficher toutes les quêtes d'un cursus

--Affiche tous les événements auxquels une personne doit assister durant une période