DROP TABLE TICKET;
DROP TABLE SEAT;
DROP TABLE SHOWTIME;
DROP TABLE THEATRE;
DROP TABLE REVIEW;
DROP TABLE "MEMBER";
DROP TABLE "MOVIE_ACTOR";
DROP TABLE "MOVIE_CATEGORY";
DROP TABLE ACTOR;
DROP TABLE "CATEGORY";
DROP TABLE MOVIE;
DROP TABLE SELL;
DROP TABLE EMPLOYEE;
DROP TABLE FOOD;
DROP TABLE PERSON;

drop trigger "WATCHANAN"."ACTOR_TRG";
drop trigger "WATCHANAN"."CATEGORY_TRG";
drop trigger "WATCHANAN"."EMPLOYEE_TRG";
drop trigger "WATCHANAN"."FOOD_TRG";
drop trigger "WATCHANAN"."MEMBER_TRG";
drop trigger "WATCHANAN"."MOVIE_TRG";
drop trigger "WATCHANAN"."TICKET_TRG";

drop sequence "WATCHANAN"."ACTOR_SEQ";
drop sequence "WATCHANAN"."CATEGORY_SEQ";
drop sequence "WATCHANAN"."EMPLOYEE_SEQ";
drop sequence "WATCHANAN"."FOOD_SEQ";
drop sequence "WATCHANAN"."MEMBER_SEQ";
drop sequence "WATCHANAN"."MOVIE_SEQ";
drop sequence "WATCHANAN"."TICKET_SEQ";