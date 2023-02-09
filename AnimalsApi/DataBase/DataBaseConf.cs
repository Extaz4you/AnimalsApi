using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.DataBase
{
    internal class DataBaseConf
    {

            public static void PrepareDatabase()
            {
                using MySqlConnection connection = new DBMySQLUtils().CreateSchemaConnection();
                connection.Open();

                MySqlCommand command = connection.CreateCommand();


            command.CommandText = "CREATE DATABASE IF NOT EXISTS AnimalsAPI";
                command.ExecuteNonQuery();

                command.CommandText = "USE AnimalsAPI";
                command.ExecuteNonQuery();

                command.CommandText =
                        @"CREATE TABLE IF NOT EXISTS AnimalType(
                    AnimalTypeId INTEGER PRIMARY KEY auto_increment,
                    kind VARCHAR(45)
                    )";
                command.ExecuteNonQuery();
                command.CommandText =
                        @"CREATE TABLE IF NOT EXISTS Ability(
                    AbilityId INTEGER PRIMARY KEY auto_increment,
                    AnimalTypeId INTEGER,
                    Ability VARCHAR(45),
                    FOREIGN KEY (AnimalTypeId) REFERENCES AnimalType (AnimalTypeId) ON DELETE CASCADE
                    )";
                command.ExecuteNonQuery();
                command.CommandText =
                        @"CREATE TABLE IF NOT EXISTS Animal(
                    AnimalId INTEGER PRIMARY KEY auto_increment,
                   AnimalTypeId INTEGER,
                    name VARCHAR(45),
                    birthday DATETIME,
                    description VARCHAR(250),
                    FOREIGN KEY (AnimalTypeId) REFERENCES AnimalTypeId (AnimalTypeId) ON DELETE CASCADE
                    )";
                command.ExecuteNonQuery();
                command.CommandText =
                        @"CREATE TABLE IF NOT EXISTS AnimalAbility(
                    AnimalAbilityId INTEGER PRIMARY KEY auto_increment,
                    AnimalId INTEGER,
                    AbilityId INTEGER,
                    FOREIGN KEY (idanimal) REFERENCES animal (AnimalId) ON DELETE CASCADE,
                    FOREIGN KEY (AbilityId) REFERENCES Ability (AbilityId) ON DELETE CASCADE
                    )";
                command.ExecuteNonQuery();
            }
        }
    }

