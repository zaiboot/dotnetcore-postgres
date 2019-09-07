--CREATE DATABASE customers;
--\c customers

DROP TABLE Customer;


CREATE TABLE Customer ( Id SERIAL PRIMARY KEY,
                        CustomerName VARCHAR(100) NOT NULL,
                        ClaimedAmount REAL NOT NULL DEFAULT 0
                    );