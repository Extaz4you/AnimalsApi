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
    public class AnimalRepository : IAnimalREP
    {
        public int Create(Animal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO animal(AnimalTypId, name, birthday, description) 
                                        VALUES(@AnimalTypeId, @name, @birthday, @description)";
            command.Parameters.Add("@AnimalTypeId", MySqlDbType.Int32).Value = item.AnimalTypeId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Name;
            command.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = item.Birthday;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.Description;
            return command.ExecuteNonQuery();
        }

        public int Update(Animal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE animal SET 
                                    name = @name,
                                    birthday = @birthday,
                                    description = @description
                                    WHERE AnimalId=@AnimalId";
            command.Parameters.Add("@AnimalId", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Name;
            command.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = item.Birthday;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.Description;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM animal WHERE AnimalId=@AnimalId";
            command.Parameters.Add("AnimalId", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Animal> GetAll()
        {
            List<Animal> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    AnimalTypeId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                list.Add(animal);
            }
            return list;
        }

        public IList<Animal> GetAllByAnimalTypeIdd(int id)
        {
            List<Animal> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal WHERE AnimalTypeId=@AnimalTypeId";
            command.Parameters.Add("@AnimalTypeId", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    AnimalTypeId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                list.Add(animal);
            }
            return list;
        }

        public Animal GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal WHERE AnimalId=@AnimalId";
            command.Parameters.Add("@AnimalId", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    AnimalTypeId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                return animal;
            }
            else
            {
                return null;
            }
        }

    }
}
