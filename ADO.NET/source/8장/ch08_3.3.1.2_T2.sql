-- 3.3.1 반복불가능 읽기 문제와 방지를 위한 명령어
--반복불가능 읽기 문제를 방지하기 위한 명령어-REPEATABLE READ 모드 

--T2
/* READ COMMITTED 모드(기본 모드) */

/* 2번째 실행 */


BEGIN TRAN
USE Madang
SELECT bookid, bookname, publisher, price 
FROM  Book 
WHERE bookid=1;

SELECT SUM(price) 총액 
FROM   Book;
/* 여기까지 실행해본 후 진행한다 */

/* 3 번째 실행 */

UPDATE Book 
SET      price=price+500
WHERE   bookid=1;

--쿼리를 실행하는 중 ...
/* 대기상태가 된다.
   T1이 COMMIT하면 실행된다.*/

/* 5 번째 실행 */
SELECT SUM(price) 총액 
FROM   Book;
COMMIT;
