--3.1.1 오손읽기 
/* T2(쓰는 트랜잭션) */
/* READ COMMITTED 모드 */

/* 2번째 실행 */
BEGIN TRAN
USE Madang
UPDATE Users 
SET      age=21 
WHERE   id=1;
/* No commit here */

SELECT * 
FROM   Users 
WHERE  id=1

/* 4번째 실행 */
ROLLBACK; 

