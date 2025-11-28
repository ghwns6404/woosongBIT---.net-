--3.1.1 오손읽기 
/* T1(읽는 트랜잭션)  */
/* READ UNCOMMITTED 모드 */
/* 1첫번째 실행*/
BEGIN TRAN
USE   Madang
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

SELECT * 
FROM   Users 
WHERE  id=1;


/* 3번째 실행 */
SELECT * 
FROM   Users 
WHERE  id=1;


/* 5번째 실행 */
SELECT * 
FROM   Users 
WHERE  id=1;
COMMIT;

