---Script de populación
INSERT INTO Courses(code,name,credits,school)
VALUES('AD0000','Default Course',0,'TEC');
INSERT INTO Semesters(year, period)
VALUES((SELECT YEAR(CURRENT_TIMESTAMP)),0);
INSERT INTO Groups(number,year_semester,period_semester,code_course,path)
VALUES(0,(SELECT YEAR(CURRENT_TIMESTAMP)),0,'AD0000','PENDING');
INSERT INTO Rubrics(name,number_group,year_semester,period_semester,code_course,porcentage)
VALUES('Quices',0,(SELECT YEAR(CURRENT_TIMESTAMP)),0,'AD0000',30),
	('Examenes',0,(SELECT YEAR(CURRENT_TIMESTAMP)),0,'AD0000',30),
	('Proyectos',0,(SELECT YEAR(CURRENT_TIMESTAMP)),0,'AD0000',40);
/*
DELETE FROM Rubrics WHERE name = 'Quices';
DELETE FROM Rubrics WHERE name = 'Proyectos';
DELETE FROM Rubrics WHERE name = 'Examenes';
DELETE FROM Groups where number = 0;
DELETE FROM Semesters where period = '0';
DELETE FROM Courses WHERE code = 'AD0000';*/

