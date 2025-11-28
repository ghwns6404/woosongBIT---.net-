-- 3.3.1 반복불가능 읽기 문제와 방지를 위한 명령어
-- 반복불가능 읽기 문제 
/* T2  */
/* READ COMMITTED 모드(기본 모드) */

/* 2번째 실행 */


BEGIN TRAN
USE Madang
SELECT bookid, bookname, publisher, price 
FROM  Book 
WHERE bookid=1;

SELECT SUM(price) 총액 
FROM   Book;

/* 3 번째 실행 */

UPDATE Book 
SET      price=price+500
WHERE   bookid=1;

SELECT SUM(price) 총액 
FROM   Book;

COMMIT;
