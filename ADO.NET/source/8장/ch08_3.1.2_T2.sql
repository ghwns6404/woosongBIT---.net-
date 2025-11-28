--3.1.2 반복불가능 읽기
/* T2(쓰는 트랜잭션) */
/* READ COMMITTED 모드 */


/* 2번째 실행 */
BEGIN TRAN
USE Madang
UPDATE Users 
SET     age=21 
WHERE  id=1;

COMMIT;

SELECT * 
FROM   Users 
WHERE  id=1;





