--------------------------------------------------------
--  File created - วันอาทิตย์-ธันวาคม-04-2559   
--------------------------------------------------------
REM INSERTING into THEATRE
SET DEFINE OFF;
Insert into THEATRE (THEATREID,SEATCAPACITY) values (1,100);
Insert into THEATRE (THEATREID,SEATCAPACITY) values (2,100);
Insert into THEATRE (THEATREID,SEATCAPACITY) values (3,100);
Insert into THEATRE (THEATREID,SEATCAPACITY) values (4,100);

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