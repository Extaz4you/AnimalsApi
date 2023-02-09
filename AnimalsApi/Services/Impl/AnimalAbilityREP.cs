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
    public class AnimalAbilityREP : IAnimalAbilityREP
    {
        public int Create(AnimalAbility item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO AnimalAbility(AnimalId, AbilityId) 
                                        VALUES(@AnimalId, @AbilityID)";
            command.Parameters.Add("@AnimalId", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@AbilityId", MySqlDbType.Int32).Value = item.AbilityId;
            return command.ExecuteNonQuery();
        }

        public int Update(AnimalAbility item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE AnimalAbility SET 
                                    AbilityId = @AbilityId
                                    WHERE AnimalAbilityId = @AnimalAbilityId";
            command.Parameters.Add("@AnimalAbilityId", MySqlDbType.Int32).Value = item.AnimalAbilityId;
            command.Parameters.Add("@AnimalId", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@AnimalAbilityId", MySqlDbType.Int32).Value = item.AnimalAbilityId;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM AnimalAbility WHERE AnimalAbility=@AnimalAbilityId";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<AnimalAbility> GetAll()
        {
            List<AnimalAbility> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalAbility";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalAbility animalAbility = new()
                {
                    AnimalAbilityId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    AbilityId = reader.GetInt32(2),
                };
                list.Add(animalAbility);
            }
            return list;
        }

        public IList<AnimalAbility> GetAllByAnimalId(int id)
        {
            List<AnimalAbility> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalAbility WHERE AnimalId=@AnimalId";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalAbility animalAbility = new()
                {
                    AnimalAbilityId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    AbilityId = reader.GetInt32(2),
                };
                list.Add(animalAbility);
            }
            return list;
        }

        public IList<AnimalAbility> GetAllBySkillId(int id)
        {
            List<AnimalAbility> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalAbility WHERE AbilityId=@AbilityId";
            command.Parameters.Add("@AbilityId", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalAbility animalAbility = new()
                {
                    AnimalAbilityId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    AbilityId = reader.GetInt32(2),
                };
                list.Add(animalAbility);
            }
            return list;
        }

        public AnimalAbility GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM AnimalAbility WHERE AnimalAbilityId=@AnimalAbilityId";
            command.Parameters.Add("@AnimalAbilityId", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                AnimalAbility animalAbility = new()
                {
                    AnimalAbilityId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    AbilityId = reader.GetInt32(2),
                };
                return animalAbility;
            }
            else
            {
                return null;
            }
        }
    }
}
