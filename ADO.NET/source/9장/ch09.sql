-- 질의 9-1 (sa 로그인 창) 새로운 로그인 이름 mdguest2를 생성한 후 Madang 데이터베이스에 접근할 수 있도록
하시오.
USE master;
CREATE LOGIN mdguest2 WITH PASSWORD = 'mdpass',
default_database=Madang;
GO
USE [Madang]
GO
CREATE USER mdguest2 FOR LOGIN mdguest2
WITH default_schema=dbo;
GO

-- 질의 9-2 (mduser 로그인 창) mdguest에게 Book 테이블의 SELECT 권한을 부여하시오.
GRANT SELECT ON Book TO mdguest;

-- 질의 9-3 (mduser 로그인 창) mdguest에게 Customer 테이블의 SELECT, UPDATE 권한을 WITH
GRANT OPTION과 함께 부여하시오.
GRANT SELECT, UPDATE ON Customer TO mdguest WITH GRANT OPTION;

-- 질의 9-4 (mdguest 로그인 창) Book 테이블과 Customer 테이블의 SELECT 권한을 mdguest2에 부여하시오.
GRANT SELECT ON Book TO mdguest2;

-- 질의 9-5 (mduser 로그인 창) Orders 테이블을 모든 사용자가 SELECT할 수 있도록 권한을 부여하시오.
GRANT SELECT ON Orders TO PUBLIC;

-- 질의 9-6 (mduser 로그인 창) mdguest로부터 Book 테이블의 SELECT 권한을 취소하시오.
REVOKE SELECT ON Book FROM mdguest;

-- 질의 9-7 (mduser 로그인 창) mdguest로부터 Customer 테이블의 SELECT 권한을 취소하시오. 
REVOKE SELECT ON Customer FROM mdguest;

-- 질의 9-8 (sa 로그인창) Madang DB에 programmer라는 롤을 생성하시오.
USE Madang;
GO
CREATE ROLE programmer;

-- 질의 9-9 (sa 로그인창) programmer 롤에 Book과 Orders 테이블에 대한 권한을 부여하시오.
GRANT SELECT, UPDATE ON Book TO programmer;
GO
GRANT SELECT, INSERT ON Orders TO programmer;
GO

-- 질의 9-10 (sa 로그인창) programmer에 mdguest와 mdguest2 사용자를 추가하시오.
EXEC sp_addrolemember programmer, mdguest;
GO
EXEC sp_addrolemember programmer, mdguest2;
GO

-- 질의 9-11 (mdguest 로그인 창) Book 테이블에서 도서번호 1번을 조회(SELECT)한 후 다음과 같이 데이터를
추가(INSERT)하시오.
SELECT *
FROM Book
WHERE bookid=1;

INSERT INTO Book(bookid, bookname, publisher, price)
VALUES (100, '좋은책', '좋은출판사', 100);

-- 질의 9-12 (sa 로그인창) Madang DB에 programmer 롤을 삭제하시오.
USE Madang;
GO
EXEC sp_droprolemember programmer, mdguest;
GO
EXEC sp_droprolemember programmer, mdguest2;
GO
DROP ROLE programmer;

-- 질의 9-13 (mdguest 로그인 창) Book 테이블에서 도서번호 1번을 조회(SELECT)해보시오.
SELECT *
FROM Book
WHERE bookid=1;
