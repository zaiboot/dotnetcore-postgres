--CREATE DATABASE prizes;
-- \c prizes

--SELECT current_database();

--CREATE DATABASE customers;
--\c customers
-- DROP TABLE Customer;
-- CREATE TABLE Customer (
--    Id SERIAL PRIMARY KEY,
--    CustomerName VARCHAR(100) NOT NULL,
--    ClaimedAmount REAL NOT NULL DEFAULT 0
-- );


--SELECT * FROM customer;

--SELECT c."Id", c."ClaimedAmount", c."CustomerName" FROM Customer AS c
--INSERT INTO customer(customername) values('WPN User'); -- default user no  data

DROP TABLE IF EXISTS prize
CREATE TABLE prize(
    id SERIAL PRIMARY KEY,
    amount REAL NOT NULL DEFAULT 0,
    name VARCHAR(100) NOT NULL
)