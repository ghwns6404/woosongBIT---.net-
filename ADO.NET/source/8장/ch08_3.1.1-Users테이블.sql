/* 실험 테이블 생성 */
USE Madang;
Drop TABLE Users;
CREATE TABLE Users
	( id INTEGER, 
         name VARCHAR(20), 
         age INTEGER); 
INSERT INTO Users VALUES(1, 'HONG GILDONG', 30);

SELECT * 
FROM Users;