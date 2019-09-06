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
--INSERT INTO customer(id, customername) values(1, 'WPN User'); -- default user no  data

SELECT * FROM customer;