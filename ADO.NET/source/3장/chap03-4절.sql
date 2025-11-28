-- 질의 3-34 다음과 같은 속성을 가진 NewBook 테이블을 생성하시오
CREATE TABLE NewBook
( bookid 	INT,
  bookname 	VARCHAR(20),
  publisher VARCHAR(20),
  price 	INT);

-- 질의 3-35 다음과 같은 속성을 가진 NewCustomer 테이블을 생성하시오.
CREATE TABLE NewCustomer
( custid   	INT 		PRIMARY KEY,  
  name     	VARCHAR(40),
  address   VARCHAR(40),
  phone     VARCHAR(30));

-- 질의 3-36 다음과 같은 속성을 가진 NewOrders 테이블을 생성하시오.
CREATE TABLE NewOrders
( orderid	INT,
  custid	INT		NOT NULL,
  bookid	INT		NOT NULL,
  saleprice	INT,
  orderdate DATE,		
  PRIMARY KEY (orderid),
  FOREIGN KEY (custid) REFERENCES NewCustomer(custid)  ON DELETE CASCADE);

-- 질의 3-37 NewBook 테이블에 VARCHAR(13)의 자료형을 가진 isbn 속성을 추가하시오.
ALTER TABLE NewBook ADD isbn VARCHAR(13);

-- 질의 3-38 NewBook 테이블의 isbn 속성의 데이터 타입을 INT형으로 변경하시오.
ALTER TABLE NewBook ALTER COLUMN isbn INT; 

-- 질의 3-39 NewBook 테이블의 isbn 속성을 삭제하시오.
ALTER TABLE NewBook DROP COLUMN isbn; 

-- 질의 3-40 NewBook 테이블의 bookid 속성에 NOT NULL 제약조건을 적용하시오.
ALTER TABLE NewBook ALTER COLUMN bookid INT NOT NULL; 

-- 질의 3-41 NewBook 테이블의 bookid 속성을 기본키로 변경하시오.
ALTER TABLE NewBook ADD PRIMARY KEY (bookid);

-- 질의 3-42 NewBook 테이블을 삭제하시오.
DROP TABLE NewBook;

-- 질의 3-43 NewCustomer 테이블을 삭제하시오. 만약 삭제가 거절된다면 원인을 파악하고 관련된 테이블을 같
이 삭제하시오.
DROP TABLE NewOrders;
DROP TABLE NewCustomer;
