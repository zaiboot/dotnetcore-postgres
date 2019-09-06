--CREATE DATABASE prizes;
DROP TABLE IF EXISTS prize;
DROP TABLE IF EXISTS prize_customer;
DROP TYPE IF EXISTS StatusEnum;

CREATE TABLE prize(
    id SERIAL PRIMARY KEY,
    amount REAL NOT NULL DEFAULT 0,
    name VARCHAR(100) NOT NULL
);

CREATE TYPE StatusEnum as ENUM('AVAILABLE', 'NOT_AVAILABLE', 'MISSED', 'NOT_INITIALIZED');



CREATE TABLE prize_customer(
    id SERIAL PRIMARY KEY,
    customerId INT NOT NULL, --We are using microservices so this data is not supposed to be validated by the DB but the app itself
    amount REAL NOT NULL DEFAULT 0, --storing the value in the time we added it, just in case prize changes
    prize_status StatusEnum DEFAULT 'NOT_INITIALIZED'
);

INSERT INTO prize(amount, name) values(100, 'prize10');
INSERT INTO prize(amount, name) values(100, 'prize11');
INSERT INTO prize(amount, name) values(100, 'prize20');
INSERT INTO prize(amount, name) values(100, 'prize30');
INSERT INTO prize(amount, name) values(100, 'prize40');

SELECT * from prize;

INSERT INTO prize_customer(customerId, amount, prize_status) VALUES(1, 100, 'NOT_INITIALIZED');

SELECT * FROM prize_customer;