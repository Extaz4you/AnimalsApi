using AnimalsApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApi.Services.Impl
{
    public class AbilityREP : IAbilityREP
    {
        public int Create(Ability item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Ability(AnimalTypeId, Ability) 
                                        VALUES(@AnimalTypeId, @Ability)";
            command.Parameters.Add("@AnimalTypeeId", MySqlDbType.Int32).Value = item.AnimalTypeId;
            command.Parameters.Add("@Ability", MySqlDbType.VarChar).Value = item.CharAbility;
            return command.ExecuteNonQuery();
        }

        public int Update(Ability item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE Ability SET 
                                    Ability = @Ability
                                    WHERE  AbilityId = @AbilityId";
            command.Parameters.Add("@AbilityId", MySqlDbType.Int32).Value = item.AbilityId;
            command.Parameters.Add("@Ability", MySqlDbType.VarChar).Value = item.CharAbility;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM Ability WHERE AbilityId=@AbilityId";
            command.Parameters.Add("@AbilityId", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Ability> GetAll()
        {
            List<Ability> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Ability";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Ability ability = new()
                {
                    AbilityId = reader.GetInt32(0),
                    AnimalTypeId = reader.GetInt32(1),
                    CharAbility = reader.GetString(2),
                };
                list.Add(ability);
            }
            return list;
        }

        public IList<Ability> GetAllByAnimalKindId(int id)
        {
            List<Ability> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Ability WHERE AnimalTypeId=@AnimalTypeId";
            command.Parameters.Add("@AnimalTypeId", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Ability ability = new()
                {
                    AbilityId = reader.GetInt32(0),
                    AnimalTypeId = reader.GetInt32(1),
                    CharAbility = reader.GetString(2),
                };
                list.Add(ability);
            }
            return list;
        }

        public Ability GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Ability WHERE AbilityId=@AbilityId";
            command.Parameters.Add("@AbilityId", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Ability ability = new()
                {
                    AbilityId = reader.GetInt32(0),
                   AnimalTypeId = reader.GetInt32(1),
                    CharAbility = reader.GetString(2),
                };
                return ability;
            }
            else
            {
                return null;
            }
        }

        public IList<Ability> GetAllByAnimalTypeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
