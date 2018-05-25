CREATE USER IF NOT EXISTS 'ODBC'@'localhost';

CREATE DATABASE IF NOT EXISTS apiproject;

USE apiproject;

CREATE TABLE IF NOT EXISTS Practices(PracticeId int NOT NULL, PracticeName varchar(50), Speciality varchar(50), LicenseNumber varchar(20), Address text, City varchar(30), State varchar(30), Zip varchar(5), Cell varchar(20), PRIMARY KEY (PracticeId));

CREATE TABLE IF NOT EXISTS Patients(PatientId int NOT NULL, FirstName varchar(50), LastName varchar(50), BirthDate date, Address text, City varchar(30), State varchar(30), MedicalNotes text, NextVisitDate date, Zip varchar(5), Cell varchar(20), PracticeId int NOT NULL, PRIMARY KEY (PatientId), FOREIGN KEY (PracticeId) REFERENCES Practices(PracticeId) ON DELETE CASCADE);

CREATE TABLE IF NOT EXISTS Appointments(PatientId int NOT NULL, PracticeId int NOT NULL, AppointmentDate date, AppointmentTime TIME, Description text, FOREIGN KEY (PracticeId) REFERENCES Practices(PracticeId), FOREIGN KEY (PatientId) REFERENCES Patients(PatientId));

INSERT INTO Practices VALUES (1, 'oncologist', 'radiation', '123567', '2101 yucca ave', 'fullerton', 'california', '91835', '2137852642'),
(2, 'allergist', 'Asthma', '261567', '15339 falcon crest st', 'san diego', 'california', '92127', '6196400231'),
(3, 'psychologist', 'child psychology', '78154', '3050 Agua Fria Fwy # 150',
'Phoenix', 'arizona', '85035', '6237852642'),
(4, 'anesthetist', 'cardiothorasic', '111376', '50 Milk St
Suite 1300', 'boston', 'massachusetts', '02109', '617-552-4275'),
(5, 'surgeon', 'general medicine', '402561', '6770 Bertner Avenue', 'Houston',
'texas', '77035', '832-355-4011');

INSERT INTO Patients VALUES (24, 'John', 'Doe', '1990-10-10', '2717 orchard ave', 'los angeles',
'california', 'stage 1 liver carsinoma, radiation recommeded', '2018-03-05', '90007', '2177600851', 1),
(12, 'Jane', 'Doe', '1993-01-15', '2352 portland st', 'irvine',
'california', 'stage 4 liver cancer,4 radiation therapy recommeded', '2017-04-15', '91247', '214760860', 1),
(5, 'Bob', 'Jacob', '2014-12-23', '170 east crest dr', 'phoenix','arizona', 'severe depression, 
4 more therapies recommended', '2018-05-13', '85014', '6275418342', 3),
(14, 'Barry', 'Finley', '1983-04-20', '903 sepulveda ave', 'alsio visio','california',
'minor asthma prescribed Bronchodilator', '2017-07-15', '92876', '2156085100', 2),
(234, 'silvia', 'plath', '1890-12-10', '15063 la jolla cove st', 'san diego','california',
'severe asthma, needs to come for check up next week, breathing test to be done', '2018-01-05', '90217', '2167615891', 2),
(102, 'angela', 'draft', '2016-09-09', '6134 bertner Ave', 'houston','texas',
'kidney transplantation was successful, regular monthly checkup to be done', '2017-12-15', '77021', '832-377-1423', 5),
(43, 'Alice', 'Preston', '2002-07-21', '1333 shore district drive', 'austin',
'texas', 'intestinal damage, stiching done for large intestine', '2018-05-20', '78741', '5124486000', 5),
(92, 'Alice', 'Preston', '1990-10-10', '4719 COLE AVENUE', 'dallas',
'texas', 'colon cancer discovered, recommended to oncologist', '2017-10-18', '78632', '5349256321', 5);

INSERT INTO Appointments VALUES (24, 1, '2018-03-15', '10:30', '1st radiation therapy for patient for liver cancer'),
(92, 1, '2018-06-18', '13:30', '1st radiation therapy for patient for colon cancer'),
(92, 1, '2018-07-18', '13:30', '2nd radiation therapy for patient for colon cancer'),
(102, 5, '2018-06-15', '09:00', 'monthly scheduled checkup for kidney function'),
(5, 3, '2018-05-23', '11:10', 'weekly therapy session - sitting 2'),
(5, 3, '2018-06-03', '11:40', 'weekly therapy session - sitting 3'),
(5, 3, '2018-06-03', '16:00', 'emergency therapy session');

GRANT ALL ON apiproject.* TO 'ODBC'@'localhost';