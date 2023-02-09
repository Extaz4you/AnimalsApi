
MySQL localhost:3306 ssl SQL > CREATE SCHEMA IF NOT EXISTS man_friends;
MySQL localhost:3306 ssl SQL > SHOW DATABASES;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| man_friends        |
| mysql              |
| performance_schema |
| sakila             |
| sys                |
| world              |
+--------------------+

MySQL localhost:3306 ssl mans_friends SQL > CREATE TABLE IF NOT EXISTS dog (
                                         ->   iddog INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
                                         ->   name VARCHAR(45) NOT NULL,
                                         ->   birthday DATETIME NOT NULL,
                                         ->   skill VARCHAR(45) NULL);

 MySQL localhost:3306 ssl mans_friends SQL > SHOW TABLES;
+------------------------+
| Tables_in_man_friends |
+------------------------+
| camel                  |
| cat                    |
| dog                    |
| donkey                 |
| hamster                |
| horse                  |
+------------------------+

 MySQL localhost:3306 ssl mans_friends SQL > INSERT dog (
                                          ->     name,
                                          ->     birthday,
                                          ->     skill
                                          -> )
                                          -> VALUES
                                          ->    ('Марс', '2022-01-01', 'Cидеть'),
                                          ->    ('Венера', '2021-01-01', 'Лежать'),
                                          ->    ('Сатурн', '2012-01-01', 'Голос');


 MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM cat;
+-------+--------+---------------------+--------+
| iddog | name   | birthday            | skill  |
+-------+--------+---------------------+--------+
|     1 | Муся   | 2018-01-01 00:00:00 | Мяу    |
|     2 | Кися   | 2020-01-01 00:00:00 | Прыжок |
+-------+--------+---------------------+--------+

MySQL localhost:3306 ssl man_friends SQL > DELETE FROM camel;

MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM camel;

MySQL localhost:3306 ssl mans_friends SQL > CREATE TABLE pack_animals (
                                         ->   idpack_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT
                                         -> )
                                         -> SELECT
                                         ->     name,
                                         ->     birthday,
                                         ->     skill,
                                         ->     'horse' as animal_type
                                         -> FROM
                                         ->     horse;

MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM pack_animals;
+----------------+--------+---------------------+---------+-------------+
| idpack_animals | name   | birthday            | skill   | animal_type |
+----------------+--------+---------------------+---------+-------------+
|              1 | Мерк   | 2018-01-01 00:00:00 | Скачи   | horse       |
|              2 | Пупок  | 2019-01-01 00:00:00 | Возить  | horse       |
+----------------+--------+---------------------+---------+-------------+

MySQL localhost:3306 ssl man_friends SQL > INSERT INTO pack_animals (
                                         ->   name,
                                         ->   birthday,
                                         ->   skill,
                                         ->   animal_type)
                                         -> SELECT name, birthday, skill, 'donkey' as animal_type
                                         -> FROM donkey;

MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM pack_animals ;
+----------------+-----------+---------------------+---------+-------------+
| idpack_animals | name      | birthday            | skill   | animal_type |
+----------------+-----------+---------------------+---------+-------------+
|              1 | Мерк      | 2018-01-01 00:00:00 | Скачи   | horse       |
|              2 | Пупок     | 2019-01-01 00:00:00 | Возить  | horse       |
|              4 | Осел      | 2021-01-01 00:00:00 | Возить  | donkey      |
|              5 | Осел2     | 2022-01-01 00:00:00 | Возить  | donkey      |
+----------------+-----------+---------------------+---------+-------------+

MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM pet;
+-------+--------+---------------------+----------------+-------------+
| idpet | name   | birthday            | skill          | animal_type |
+-------+--------+---------------------+----------------+-------------+
|     1 | Марс   | 2022-01-01 00:00:00 | Сидеть         | dog         |
|     2 | Венера | 2021-01-01 00:00:00 | Лежать         | dog         |
|     3 | Сатурн | 2012-01-01 00:00:00 | Голос          | dog         |
|     4 | Мурзик | 2018-01-01 00:00:00 | Мяу            | cat         |
|     5 | Барсик | 2020-01-01 00:00:00 | Прыжок         | cat         |
|     7 | Хомяк  | 2023-01-01 00:00:00 | Бегать         | hamster     |
+-------+--------+---------------------+----------------+-------------+

MySQL localhost:3306 ssl man_friends SQL > CREATE TABLE young_animals (
                                         ->   idyoung_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT
                                         -> )
                                         -> SELECT
                                         ->   name,
                                         ->   birthday,
                                         ->   skill,
                                         ->   animal_type,
                                         ->   (TIMESTAMPDIFF(MONTH, birthday, CURDATE())) as age_months
                                         -> FROM
                                         ->   (SELECT * FROM pack_animals UNION SELECT * FROM pet) s
                                         -> WHERE birthday BETWEEN CURDATE() - INTERVAL 3 YEAR 
                                         ->       AND CURDATE() - INTERVAL 1 YEAR;


MySQL localhost:3306 ssl mans_friends SQL > SELECT * FROM young_animals;
+-----------------+-----------+---------------------+--------+-------------+------------+
| idyoung_animals | name      | birthday            | skill  | animal_type | age_months |
+-----------------+-----------+---------------------+--------+-------------+------------+
|               1 | Осел      | 2021-01-01 00:00:00 | Возить | donkey      |         25 |
|               2 | Осел1     | 2022-01-01 00:00:00 | Возить | donkey      |         13 |
|               3 | Марс      | 2022-01-01 00:00:00 | Сидеть | dog         |         13 |
|               4 | Венера    | 2021-01-01 00:00:00 | Лежать | dog         |         25 |
+-----------------+-----------+---------------------+--------+-------------+------------+

MySQL localhost:3306 ssl man_friends SQL > CREATE TABLE animals (
                                         -> idanimals INT PRIMARY KEY NOT NULL AUTO_INCREMENT
                                         -> )
                                         -> SELECT
                                         ->   name,
                                         ->   birthday,
                                         ->   skill,
                                         ->   animal_type
                                         -> FROM
                                         ->   (SELECT * FROM pack_animals UNION SELECT * FROM pet) s;

MySQL localhost:3306 ssl man_friends SQL > SELECT * FROM animals;
+-----------+-----------+---------------------+----------------+-------------+
| idanimals | name      | birthday            | skill          | animal_type |
+-----------+-----------+---------------------+----------------+-------------+
|         1 | Мерк      | 2018-01-01 00:00:00 | Скачи          | horse       |
|         2 | Пупок     | 2019-01-01 00:00:00 | Возить         | horse       |
|         3 | Осел      | 2021-01-01 00:00:00 | Возить         | donkey      |
|         4 | Осел1     | 2022-01-01 00:00:00 | Возить         | donkey      |
|         5 | Марс      | 2022-01-01 00:00:00 | Сидеть         | dog         |
|         6 | Венера    | 2021-01-01 00:00:00 | Лежать         | dog         |
|         7 | Сатурн    | 2012-01-01 00:00:00 | Голос          | dog         |
|         8 | Муся      | 2018-01-01 00:00:00 | Мяу            | cat         |
|         9 | Кися      | 2020-01-01 00:00:00 | Прыжок         | cat         |
|        10 | Хомяк     | 2023-01-01 00:00:00 | бегать         | hamster     |
+-----------+-----------+---------------------+----------------+-------------+
