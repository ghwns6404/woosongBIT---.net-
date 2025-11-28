--3.3.2 유령데이터 읽기 문제와 방지를 위한 명령어 
--유령데이터 읽기 문제
--T1
--REPEATABLE READ 모드
/* 1번째 실행 */
BEGIN TRAN
USE Madang
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
SELECT SUM(price) 총액 
FROM Book;


/* 3번째 실행 */
SELECT SUM(price) 총액 
FROM   Book;

/* 앞의 결과와  다름 */
COMMIT;
