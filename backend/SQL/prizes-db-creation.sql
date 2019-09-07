--CREATE DATABASE prizes;
DROP TABLE IF EXISTS prize_customer;
DROP TYPE IF EXISTS StatusEnum;

CREATE TYPE StatusEnum as ENUM('AVAILABLE', 'NOT_AVAILABLE', 'MISSED', 'NOT_INITIALIZED');

CREATE TABLE prize_customer(
    id SERIAL PRIMARY KEY,
    prizename VARCHAR(100) NOT NULL, 
    customerId INT NOT NULL, --We are using microservices so this data is not supposed to be validated by the DB but the app itself
    amount REAL NOT NULL DEFAULT 0, 
    prize_status StatusEnum DEFAULT 'NOT_INITIALIZED'
);

INSERT INTO prize_customer(amount, prizename, customerId) values(100, 'prize10',1);
INSERT INTO prize_customer(amount, prizename, customerId) values(100, 'prize11',1);
INSERT INTO prize_customer(amount, prizename, customerId) values(100, 'prize20',1);
INSERT INTO prize_customer(amount, prizename, customerId) values(100, 'prize30',1);
INSERT INTO prize_customer(amount, prizename, customerId) values(100, 'prize40',1);

SELECT * from prize_customer;