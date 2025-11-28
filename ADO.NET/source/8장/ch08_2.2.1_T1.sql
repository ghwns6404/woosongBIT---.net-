--2.2.1.
--[시나리오] SQL Server에서 2개의 갱신 트랜잭션 동시 실행
--T1

--1번째 실행
USE Madang;
BEGIN TRAN;
SELECT * 
FROM   Book
WHERE bookid=1;

UPDATE book 
SET     price=7100
WHERE  bookid=1;

--3번째 실행
SELECT * 
FROM   Book
WHERE  bookid=1;
COMMIT;

