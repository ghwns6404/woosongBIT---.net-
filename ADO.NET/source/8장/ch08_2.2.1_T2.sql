--2.2.1.
--[시나리오] SQL Server에서 2개의 갱신 트랜잭션 동시 실행
--T2

--2번째 실행

Use Madang;
BEGIN TRAN;
SELECT * 
FROM   Book
WHERE  bookid=1;

UPDATE Book 
SET     price=price+100
WHERE  bookid=1;
--...(대기 상태)...

--4번째 실행
SELECT * 
FROM   Book
WHERE  bookid=1;
COMMIT;
