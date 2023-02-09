using AnimalsApi.DataBase;
using AnimalsApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Services.Impl
{
    public class AnimalTypeREP : IAnimalTypeREP
    {
        public int Create(AnimalType item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO AnimalType(type) 
                                        VALUES(@type)";
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = item.Type;
            return command.ExecuteNonQuery();
        }

        public int Update(AnimalType item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE AnimalType SET 
                                    type = @type
                                    WHERE idAnimalType=@idAnimalType";
            command.Parameters.Add("@idAnimalType", MySqlDbType.Int32).Value = item.AnimalTypeId;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = item.Type;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM AnimalType WHERE idAnimalType=@idAnimalType";
            command.Parameters.Add("@idAnimalType", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<AnimalType> GetAll()
        {
            List<AnimalType> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalType";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalType animalType = new()
                {
                    AnimalTypeId = reader.GetInt32(0),
                    Type = reader.GetString(1)
                };
                list.Add(animalType);
            }
            return list;
        }

        public AnimalType GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalType WHERE idAnimalType=@idAnimalType";
            command.Parameters.Add("@idAnimalType", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                AnimalType animalType = new()
                {
                    AnimalTypeId = reader.GetInt32(0),
                    Type = reader.GetString(1)
                };
                return animalType;
            }
            else
            {
                return null;
            }
        }

    }
}
