--3.3.2 유령데이터 읽기 문제와 방지를 위한 명령어 
--유령데이터 읽기 문제를 방지하기 위한 명령어 - SERIALIZABLE 모드 
--T1
--SERIALIZABLE 모드

/* 1번째 실행 */

BEGIN TRAN
use Madang
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
SELECT SUM(price) 총액 
FROM Book;

/* 4번째 실행 */

SELECT SUM(price) 총액 
FROM   Book;

/* 앞의 결과와  같음 */

COMMIT;

