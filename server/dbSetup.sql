-- Active: 1707325572436@@SG-sandy-boii-db-8111-mysql-master.servers.mongodirector.com@3306@sand
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(1000) COMMENT 'User Picture',
    Bio VARCHAR(2000) COMMENT 'User Bio',
    CoverImg varchar(1000) COMMENT 'User CoverImg',
    GitHub VARCHAR(255) COMMENT 'User GitHub',
    LinkedIn VARCHAR(255) COMMENT 'User LinkedIn'
) default charset utf8 COMMENT '';

CREATE TABLE recipes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255) NOT NULL,
    instructions VARCHAR(1220) NOT NULL,
    img VARCHAR(610) NOT NULL DEFAULT '',
    category VARCHAR(255),
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE ingredients (
    id INT AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    quantity VARCHAR(255) NOT NULL,
    recipeId int NOT NULL,
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE favorites (
    id INT AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    recipeId int,
    FOREIGN KEY (recipeId) REFERENCES recipes (id),
    accountId VARCHAR(255),
    FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SELECT
    recipes.*,
    favorites.id
FROM
    recipes
    JOIN favorites ON favorites.recipeId = recipes.id
WHERE
    favorites.accountId = "65835d5f80d80bc692d5d8ed"
Select
    ingredients.*,
    recipes.creatorId
from
    ingredients
    JOIN recipes ON recipes.id = ingredients.recipeId
WHERE
    ingredients.id = 6;