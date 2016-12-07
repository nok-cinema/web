--------------------------------------------------------
--  File created - Sunday-December-04-2016   
--------------------------------------------------------
REM INSERTING into PERSON
SET DEFINE OFF;
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1208412802272','Joey','Sharleen','F',to_date('09-NOV-92','DD-MON-RR'),null,'Joey_Sharleen@mail.com','Joey','111');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1212425406260','Sevda','Kourtney','F',to_date('21-JAN-93','DD-MON-RR'),null,'Sevda_Kourtney@mail.com','Sevda','222');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1276431783219','Roddy','Daan
','M',to_date('17-AUG-93','DD-MON-RR'),null,'Roddy_Daan
@mail.com
','Roddy','333');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1428877531783','Duane','Monty','M',to_date('05-MAR-95','DD-MON-RR'),null,'Duane_Monty@mail.com','Duane','444');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1468335868683','Ned','Gerald','M',to_date('28-MAR-95','DD-MON-RR'),null,'Ned_Gerald@mail.com','Ned','555');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('1828253141115','Bryson','Randall','M',to_date('20-JUL-95','DD-MON-RR'),null,'Bryson_Randall@mail.com','Bryson','666');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('2816463207348','Marly','Joleen','F',to_date('08-JUL-96','DD-MON-RR'),null,'Marly_Joleen@mail.com','Marly','777');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('3041255857816','Susie','Liselot','F',to_date('26-DEC-96','DD-MON-RR'),null,'Susie_Liselot@mail.com','Susie','888');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('3344575388531','Payton','Marshal','M',to_date('14-FEB-97','DD-MON-RR'),null,'Payton_Marshal@mail.com','Payton','999');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('4381660441722','Mike','Audley','M',to_date('27-FEB-97','DD-MON-RR'),null,'Mike_Audley@mail.com','Mike','000');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('5107315332413','Raylene','Love','F',to_date('11-DEC-97','DD-MON-RR'),null,'Raylene_Love@mail.com','Raylene','111');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('5582053484248','Wilma','Rina','F',to_date('22-APR-98','DD-MON-RR'),null,'Wilma_Rina@mail.com','Wilma','222');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('5657605345050','Max','Derya','M',to_date('12-MAY-98','DD-MON-RR'),null,'Max_Derya@mail.com','Max','333');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('6324583038531','Huub','Fletcher','M',to_date('13-OCT-98','DD-MON-RR'),null,'Huub_Fletcher@mail.com','Huub','444');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('6770282313551','Osbert','Byron','M',to_date('02-NOV-98','DD-MON-RR'),null,'Osbert_Byron@mail.com','Osbert','555');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('7085461784841','Scarlett','Debi','F',to_date('25-MAR-99','DD-MON-RR'),null,'Scarlett_Debi@mail.com','Scarlett','666');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('7325307882666','Angie','Gena','F',to_date('12-MAY-99','DD-MON-RR'),null,'Angie_Gena@mail.com','Angie','777');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('7372874747461','Carolien','Kailee','F',to_date('03-SEP-99','DD-MON-RR'),null,'Carolien_Kailee@mail.com','Carolien','888');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('8063213515341','Raine','Eduard','M',to_date('17-OCT-99','DD-MON-RR'),null,'Raine_Eduard@mail.com','Raine','999');
Insert into PERSON (CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD) values ('8456872381711','Paula','Nena','F',to_date('18-DEC-99','DD-MON-RR'),null,'Paula_Nena@mail.com','Paula','000');

--------------------------------------------------------
--  File created - Sunday-December-04-2016   
--------------------------------------------------------
REM INSERTING into EMPLOYEE
SET DEFINE OFF;
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (21,'Manager',2500,'1208412802272');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (22,'Accountant',1500,'1212425406260');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (23,'Satff',1000,'1276431783219');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (24,'Satff',1000,'1428877531783');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (25,'Satff',1000,'1468335868683');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (26,'Satff',1000,'1828253141115');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (27,'Cleaner',500,'2816463207348');
Insert into EMPLOYEE (EMPID,JOBPOSITION,SALARY,CITIZENID) values (28,'Cleaner',500,'3041255857816');

--------------------------------------------------------
--  File created - Sunday-December-04-2016   
--------------------------------------------------------
REM INSERTING into MEMBER
SET DEFINE OFF;
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (1,to_date('01-DEC-16','DD-MON-RR'),to_date('01-DEC-17','DD-MON-RR'),'3344575388531');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (2,to_date('01-DEC-16','DD-MON-RR'),to_date('01-DEC-17','DD-MON-RR'),'4381660441722');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (3,to_date('02-DEC-16','DD-MON-RR'),to_date('02-DEC-17','DD-MON-RR'),'5107315332413');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (4,to_date('05-DEC-16','DD-MON-RR'),to_date('05-DEC-17','DD-MON-RR'),'5582053484248');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (5,to_date('05-DEC-16','DD-MON-RR'),to_date('05-DEC-17','DD-MON-RR'),'5657605345050');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (6,to_date('05-DEC-16','DD-MON-RR'),to_date('05-DEC-17','DD-MON-RR'),'6324583038531');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (7,to_date('07-DEC-16','DD-MON-RR'),to_date('07-DEC-17','DD-MON-RR'),'6770282313551');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (8,to_date('07-DEC-16','DD-MON-RR'),to_date('07-DEC-17','DD-MON-RR'),'7085461784841');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (9,to_date('08-DEC-16','DD-MON-RR'),to_date('08-DEC-17','DD-MON-RR'),'7325307882666');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (10,to_date('11-DEC-16','DD-MON-RR'),to_date('11-DEC-17','DD-MON-RR'),'7372874747461');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (11,to_date('15-DEC-16','DD-MON-RR'),to_date('15-DEC-17','DD-MON-RR'),'8063213515341');
Insert into MEMBER (MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID) values (12,to_date('16-DEC-16','DD-MON-RR'),to_date('16-DEC-16','DD-MON-RR'),'8456872381711');

INSERT INTO "WATCHANAN"."THEATRE" (THEATREID, SEATCAPACITY) VALUES ('1', '240');
INSERT INTO "WATCHANAN"."THEATRE" (THEATREID, SEATCAPACITY) VALUES ('2', '240');
INSERT INTO "WATCHANAN"."THEATRE" (THEATREID, SEATCAPACITY) VALUES ('3', '240');
INSERT INTO "WATCHANAN"."THEATRE" (THEATREID, SEATCAPACITY) VALUES ('4', '240');

DECLARE
  snum NUMBER := 1;
  TYPE arrayRow IS TABLE OF VARCHAR2(1);
  rowChar arrayRow := arrayRow();
  BEGIN
    rowChar.EXTEND(12);
    rowChar(1) := 'A';
    rowChar(2) := 'B';
    rowChar(3) := 'C';
    rowChar(4) := 'D';
    rowChar(5) := 'E';
    rowChar(6) := 'F';
    rowChar(7) := 'G';
    rowChar(8) := 'H';
    rowChar(9) := 'I';
    rowChar(10) := 'J';
    rowChar(11) := 'K';
    rowChar(12) := 'L';
  WHILE snum <= 20 LOOP
    FOR rowRun IN 1 .. rowChar.COUNT LOOP
      INSERT INTO SEAT (SEATROW, SEATNUMBER, THEATREID) VALUES (rowChar(rowRun), snum, 1);
    END LOOP;
    snum := snum + 1;
  END LOOP;
END;
/

DECLARE
  snum NUMBER := 1;
  TYPE arrayRow IS TABLE OF VARCHAR2(1);
  rowChar arrayRow := arrayRow();
  BEGIN
    rowChar.EXTEND(12);
    rowChar(1) := 'A';
    rowChar(2) := 'B';
    rowChar(3) := 'C';
    rowChar(4) := 'D';
    rowChar(5) := 'E';
    rowChar(6) := 'F';
    rowChar(7) := 'G';
    rowChar(8) := 'H';
    rowChar(9) := 'I';
    rowChar(10) := 'J';
    rowChar(11) := 'K';
    rowChar(12) := 'L';
  WHILE snum <= 20 LOOP
    FOR rowRun IN 1 .. rowChar.COUNT LOOP
      INSERT INTO SEAT (SEATROW, SEATNUMBER, THEATREID) VALUES (rowChar(rowRun), snum, 2);
    END LOOP;
    snum := snum + 1;
  END LOOP;
END;
/

DECLARE
  snum NUMBER := 1;
  TYPE arrayRow IS TABLE OF VARCHAR2(1);
  rowChar arrayRow := arrayRow();
  BEGIN
    rowChar.EXTEND(12);
    rowChar(1) := 'A';
    rowChar(2) := 'B';
    rowChar(3) := 'C';
    rowChar(4) := 'D';
    rowChar(5) := 'E';
    rowChar(6) := 'F';
    rowChar(7) := 'G';
    rowChar(8) := 'H';
    rowChar(9) := 'I';
    rowChar(10) := 'J';
    rowChar(11) := 'K';
    rowChar(12) := 'L';
  WHILE snum <= 20 LOOP
    FOR rowRun IN 1 .. rowChar.COUNT LOOP
      INSERT INTO SEAT (SEATROW, SEATNUMBER, THEATREID) VALUES (rowChar(rowRun), snum, 3);
    END LOOP;
    snum := snum + 1;
  END LOOP;
END;
/

DECLARE
  snum NUMBER := 1;
  TYPE arrayRow IS TABLE OF VARCHAR2(1);
  rowChar arrayRow := arrayRow();
  BEGIN
    rowChar.EXTEND(12);
    rowChar(1) := 'A';
    rowChar(2) := 'B';
    rowChar(3) := 'C';
    rowChar(4) := 'D';
    rowChar(5) := 'E';
    rowChar(6) := 'F';
    rowChar(7) := 'G';
    rowChar(8) := 'H';
    rowChar(9) := 'I';
    rowChar(10) := 'J';
    rowChar(11) := 'K';
    rowChar(12) := 'L';
  WHILE snum <= 20 LOOP
    FOR rowRun IN 1 .. rowChar.COUNT LOOP
      INSERT INTO SEAT (SEATROW, SEATNUMBER, THEATREID) VALUES (rowChar(rowRun), snum, 4);
    END LOOP;
    snum := snum + 1;
  END LOOP;
END;
/

--------------------------------------------------------
--  File created - Sunday-December-04-2016   
--------------------------------------------------------
REM INSERTING into MOVIE
SET DEFINE OFF;
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (1,'Musical Touken Ranbu','Music','Tommy','This is a movie which can entertains you.','Kakashi',210,null,null,to_date('04-DEC-16','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (2,'20 Mai','Romantic','สายสมร','20 ไหม ไง','สายสมร',120,null,null,to_date('04-DEC-16','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (3,'Fantastic Beasts','Fantasy',null,null,null,132,null,null,to_date('28-NOV-73','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (4,'A Monster Calls','Fantasy',null,null,null,109,null,null,to_date('28-NOV-73','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (5,'Moana','Adventure',null,null,null,113,null,null,to_date('28-NOV-73','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (6,'Nocturnal Animals','Life',null,null,null,116,null,null,to_date('28-NOV-73','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (7,'Trolls','Animation',null,null,null,92,null,null,to_date('28-NOV-73','DD-MON-RR'));
Insert into MOVIE (MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS,SHOWDATE) values (8,'Billy Lynn Long Half Time walk','Life',null,null,null,113,null,null,to_date('28-NOV-73','DD-MON-RR'));

--------------------------------------------------------
--  File created - Sunday-December-04-2016   
--------------------------------------------------------
REM INSERTING into SHOWTIME
SET DEFINE OFF;
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 15:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 17:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 19:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 21:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 15:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 17:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 19:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 21:00:00','DD-MON-RR HH24:MI:SS'),1,1);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 15:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 17:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 19:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('04-DEC-16 21:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 15:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 17:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 19:00:00','DD-MON-RR HH24:MI:SS'),2,2);
Insert into SHOWTIME (SHOWDATE,MOVIEID,THEATREID) values (to_date('05-DEC-16 21:00:00','DD-MON-RR HH24:MI:SS'),2,2);

REM INSERTING into TICKET
SET DEFINE OFF;
INSERT INTO TICKET(EMPID, MEMBERID, SEATROW, SEATNUMBER, THEATREID, MOVIEID, SHOWDATE) VALUES (1, 1, 'F', 8, 2, 2, to_date('05/12/2016 21:00:00','DD/MM/YYYY HH24:MI:SS'));
INSERT INTO TICKET(EMPID, MEMBERID, SEATROW, SEATNUMBER, THEATREID, MOVIEID, SHOWDATE) VALUES (1, 1, 'A', 12, 2, 2, to_date('05/12/2016 21:00:00','DD/MM/YYYY HH24:MI:SS'));