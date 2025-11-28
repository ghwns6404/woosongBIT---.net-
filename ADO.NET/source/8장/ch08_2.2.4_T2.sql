--2.2.4 데드락
--SQL Server에서 데드락 발생
--T2


--2번째 실행
BEGIN TRAN
UPDATE Book 
SET     price=price*1.1
where   bookid=2;

--4번째 실행
UPDATE Book 
SET     price=price*1.1
WHERE  bookid=1;
--…(대기상태)…


