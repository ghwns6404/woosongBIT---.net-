--질의 3-44 Book 테이블에 새로운 도서 ‘스포츠 의학’을 삽입하시오. 스포츠 의학은 한솔의학서적에서 출간했으며
가격은 90,000원이다.
INSERT INTO Book(bookid, bookname, publisher, price)
	VALUES(11, '스포츠 의학', '한솔의학서적', 90000);

-- 질의 3-45 Book 테이블에 새로운 도서 ‘스포츠 의학’을 삽입하시오. 스포츠 의학은 한솔의학서적에서 출간했으며
가격은 미정이다.
INSERT INTO Book(bookid, bookname, publisher)
	VALUES(12, '스포츠 의학', '한솔의학서적');
	
-- 질의 3-46 수입도서 목록(Imported_book)을 Book 테이블에 모두 삽입하시오.
INSERT INTO Book(bookid, bookname, price, publisher)
	SELECT bookid, bookname, price, publisher
	FROM Imported_book;	
	
-- 질의 3-47 Customer 테이블에서 고객번호가 5인 고객의 주소를 ‘대한민국 부산’으로 변경하시오.
UPDATE Customer
SET address='대한민국 부산'
WHERE custid=5;

-- 질의 3-48 Customer 테이블에서 박세리 고객의 주소를 김연아 고객의 주소로 변경하시오.
UPDATE Customer
SET address = (SELECT address
	FROM Customer
	WHERE name='김연아')
WHERE name='박세리';

-- 질의 3-49 Customer 테이블에서 고객번호가 5인 고객을 삭제하시오.
DELETE
FROM Customer
WHERE custid=5;

-- 질의 3-50 모든 고객을 삭제하시오.
DELETE
FROM Customer;