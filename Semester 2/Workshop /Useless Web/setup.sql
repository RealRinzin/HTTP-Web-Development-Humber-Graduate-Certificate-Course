-- Run this SQL to set up your database
CREATE DATABASE IF NOT EXISTS banana_db;
USE banana_db;

CREATE TABLE IF NOT EXISTS banana_counter (
    id INT PRIMARY KEY DEFAULT 1,
    human BIGINT DEFAULT 0,
    monkey BIGINT DEFAULT 0,
    elephant BIGINT DEFAULT 0,
    chimpanzee BIGINT DEFAULT 0
);

-- Insert initial row (only one row needed)
INSERT INTO banana_counter (id, human, monkey, elephant, chimpanzee)
VALUES (1, 0, 0, 0, 0)
ON DUPLICATE KEY UPDATE id=1;
