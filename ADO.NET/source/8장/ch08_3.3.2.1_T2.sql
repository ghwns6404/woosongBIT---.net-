--3.3.2 유령데이터 읽기 문제와 방지를 위한 명령어 
--유령데이터 읽기 문제
--T2
--READ COMMITTED 모드(기본 모드)

/* 2번째 실행 */
BEGIN TRAN
USE Madang
SELECT SUM(price) 총액 
FROM   Book;

INSERT INTO Book VALUES(11, '테스트', '테스트출판사' , 5500);

SELECT SUM(price) 총액 
FROM Book;

COMMIT;


