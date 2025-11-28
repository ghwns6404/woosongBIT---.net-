-- 3.3.1 반복불가능 읽기 문제와 방지를 위한 명령어
--반복불가능 읽기 문제를 방지하기 위한 명령어-REPEATABLE READ 모드 

--T1
--REPEATABLE READ 모드
/* 1 번째 실행 */
BEGIN TRAN
USE Madang
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

SELECT SUM(price) 총액 
FROM   Book;


/* 4 번째 실행 */
SELECT SUM(price) 총액 
FROM   Book;

/* 앞의 결과와 같음 */
COMMIT;

