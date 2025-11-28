USE madang -- madang 데이터베이스 내부에 프로시저를 정의
DROP PROCEDURE AveragePrice -- 기존에 정의된 프로시저가 있으면 삭제 
GO

-- AveragePrice 프로시저 정의
CREATE PROCEDURE AveragePrice @AverageVal INT OUTPUT AS
BEGIN
   SET @AverageVal = (SELECT AVG(price) FROM Book 
                              WHERE price IS NOT NULL);
END
GO

-- AveragePrice 프로시저를 실행하여 Book 테이블에 저장된 도서들의 평균가격을 구함
DECLARE @Avg INT  -- 변수선언
EXEC AveragePrice @AverageVal = @Avg OUTPUT
SELECT @Avg '책값 평균' -- 변수 Avg를 출력하여 확인
GO
