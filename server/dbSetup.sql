-- Active: 1715635410117@@127.0.0.1@3306@humorous_jersey_devil_65a309_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

DROP TABLE accounts;

CREATE TABLE cars (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year INT UNSIGNED NOT NULL,
    price INT UNSIGNED NOT NULL,
    imgUrl VARCHAR(1000) NOT NULL,
    description VARCHAR(1000),
    engineType ENUM(
        "V6",
        "V8",
        "V10",
        "4-Cylinder",
        "chuncko",
        "unknown"
    ),
    color VARCHAR(255),
    mileage INT NOT NULL,
    hasCleanTitle BOOLEAN NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    -- FOREIGN KEY will not let a car be created if the creatorId on the car does not match the id of an account
    -- ON DELETE CASCADE gets rid of all orphaned data (if an account is deleted, get rid off all the cars that account created)
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO
    cars (
        make,
        model,
        year,
        price,
        imgUrl,
        description,
        engineType,
        color,
        mileage,
        hasCleanTitle,
        creatorId
    )
VALUES (
        "George",
        "Jetson",
        2000,
        1000000,
        "https://images.unsplash.com/photo-1598558543997-cd2a5d01c559?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        "Poot poot",
        "unknown",
        "silver",
        0,
        true,
        "66438c07712cf377438dedc3"
    );

SELECT * FROM cars;

SELECT * FROM accounts WHERE id = "65f87bc1e02f1ee243874743";

SELECT * FROM cars JOIN accounts ON cars.creatorId = accounts.id;

CREATE TABLE houses (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    bedrooms VARCHAR(255) NOT NULL,
    bathrooms VARCHAR(255) NOT NULL,
    levels INT UNSIGNED NOT NULL,
    price INT UNSIGNED NOT NULL,
    imgUrl VARCHAR(1000) NOT NULL,
    description VARCHAR(1000),
    year INT UNSIGNED NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO
    houses (
        bedrooms,
        bathrooms,
        levels,
        price,
        imgUrl,
        description,
        year,
        creatorId
    )
VALUES (
        5,
        3,
        3,
        100000,
        "https://www.bhg.com/thmb/FcKK-L23QiqiDVjrjLgfa1uFZU8=/4000x0/filters:no_upscale():strip_icc()/101495134_preview-b192d3b7d4b04188a014754b9ffa6f79.jpg",
        "Cool house",
        2007,
        "662ac3c1d33b7e95087433ae"
    );