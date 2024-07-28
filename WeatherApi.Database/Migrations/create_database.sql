CREATE DATABASE weather;
CREATE TABLE weather.history (
    id SERIAL PRIMARY KEY,
    city VARCHAR(255) NOT NULL,
    temperature DECIMAL(5, 2) NOT NULL,
    created_at TIMESTAMP NOT NULL
);