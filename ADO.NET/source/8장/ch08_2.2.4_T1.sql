--2.2.4 데드락
--SQL Server에서 데드락 발생
--T1

--1번째 실행
BEGIN TRAN
UPDATE Book 
SET     price=price+100
WHERE  bookid=1;

--3번째 실행
UPDATE Book 
SET     price=price+100
WHERE  bookid=2;
--…(대기상태)…

