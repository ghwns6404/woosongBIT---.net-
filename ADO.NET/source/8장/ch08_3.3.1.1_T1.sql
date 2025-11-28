-- 3.3.1 반복불가능 읽기 문제와 방지를 위한 명령어
-- 반복불가능 읽기 문제 
/* T1 */
/* READ COMMITTED 모드(기본 모드) */

/* 1 번째 실행 */
BEGIN TRAN
USE Madang
SELECT SUM(price) 총액 
FROM Book;


/* 4 번째 실행 */

SELECT SUM(price) 총액 
FROM Book;

COMMIT;
/* 앞의 결과와 다름 */