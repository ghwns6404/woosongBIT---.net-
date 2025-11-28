USE Madang -- Madang 데이터베이스 내부에 프로시저를 정의 
DROP PROCEDURE InsertBook -- 기존에 정의된 프로시저가 있으면 삭제 
GO

-- InsertBook 프로시저 정의
CREATE PROCEDURE InsertBook(@BookID INT, @BookName VARCHAR(40), 
             @Publisher VARCHAR(40), @Price INT) AS
BEGIN
     INSERT INTO dbo.Book(bookid, bookname, publisher, price) 
         VALUES (@BookID, @BookName, @Publisher, @Price);
END
GO

-- InsertBook 프로시저를 실행하여 Book 테이블에 투플 삽입하고 결과 확인
EXEC InsertBook 13, "스포츠 과학", "마당과학서적", 25000
SELECT * FROM Book; -- 13번 투플 삽입 결과 확인
GO