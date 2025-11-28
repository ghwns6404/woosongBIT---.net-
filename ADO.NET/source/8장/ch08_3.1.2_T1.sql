--3.1.2 반복불가능 읽기
/* T1(읽는 트랜잭션)*/
/* READ COMMITTED 모드*/

/* 1번째 실행 */
BEGIN TRAN
USE Madang
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

SELECT * 
FROM   Users 
WHERE  id=1;

/* 3번째 실행 */

SELECT * 
FROM   users 
WHERE  id=1;
COMMIT;


