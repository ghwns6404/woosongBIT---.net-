USE madang -- madang 데이터베이스 내부에 프로시저를 정의 
DROP TRIGGER AfterInsertBook -- 기존에 정의된 프로시저가 있으면 삭제
GO
-- AfterInterestBook 트리거 정의
CREATE TRIGGER AfterInsertBook ON Book AFTER INSERT AS
BEGIN
   DECLARE @mykey AS INT
   DECLARE @myPrice AS INT	
   DECLARE @myPublisher AS VARCHAR(40)		
   DECLARE @average AS INT
   SELECT @mykey=bookid, @myPrice=price, @myPublisher=publisher
      FROM Inserted;
   SET @average=(SELECT avg(price) FROM Book 
                 WHERE publisher LIKE @myPublisher);
   IF (@myPrice = 0) 
   BEGIN	
      UPDATE Book SET price=@average WHERE bookid=@mykey
      PRINT ' 책 가격을 출판사 평균 가격'+ 
             CONVERT(CHAR(8), @average)+ ' 으로 초기화 하였습니다.';
   END
END
GO
--  2권을 삽입하여 트리거의 실행 결과를 비교해 , INSERT 문을 실행함 
INSERT INTO Book VALUES(14,  '스포츠 과학1', '이상미디어', 0);
INSERT INTO Book VALUES(15,  '스포츠 과학2', '이상미디어', 20000);
SELECT * FROM Book; -- 결과 확인
GO
