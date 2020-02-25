CREATE TABLE books (
    isbn VARCHAR2(13) PRIMARY KEY NOT NULL,
    title VARCHAR2(255) NOT NULL,
    author VARCHAR2(255) NOT NULL,
    publication_date DATE NOT NULL,
    price INT NOT NULL,
    discount_price INT,
    instock INT NOT NULL,
    CONSTRAINT ck_price CHECK (price>=0),
    CONSTRAINT ck_discount_price CHECK (discount_price>=0)
    CONSTRAINT ck_instock CHECK (instock>=0)
)
    