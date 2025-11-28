--3.3.2 유령데이터 읽기 문제와 방지를 위한 명령어 
--유령데이터 읽기 문제를 방지하기 위한 명령어 - SERIALIZABLE 모드 
--T2
--READ COMMITTED(기본 모드)

/* 2번째 실행 */
BEGIN TRAN
USE Madang
SELECT SUM(price) 총액 
FROM   Book;

/* 여기까지 실행해본 후 진행한다*/

/* 3번째 실행 */
INSERT INTO Book VALUES(11, '테스트', '테스트출판사', 5500);

/* 대기상태가 된다. 
   T1이 COMMIT하면 실행된다.*/

/* 5번째 실행 */   
SELECT SUM(price) 총액 
FROM   Book;

COMMIT;


