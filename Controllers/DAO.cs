using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Progetto_Tipsit___Gestione_Persona.Models;
using System.Collections.Generic;

namespace Progetto_Tipsit___Gestione_Persona.Controllers
{
    public class DAO
    {
        const string connectionString = "Server=89.58.59.59;Port=3306;Database=s117_PersonaDB;Uid=u117_g1bjcGAAku;Pwd=2cZV9obe.apAp+O!STnLYQSX";
        MySqlConnection connection = new MySqlConnection(connectionString);

        public bool Create(Person person)
        {
            string q = "INSERT INTO people (firstName, lastName, age) VALUES (@fName, @lName, @age);";
            MySqlCommand cmd_Create = new MySqlCommand(q, connection);
            cmd_Create.Parameters.AddWithValue("@fName", person.FirstName);
            cmd_Create.Parameters.AddWithValue("@lName", person.LastName);
            cmd_Create.Parameters.AddWithValue("@age", person.Age);
            try
            {
                connection.Open();
                cmd_Create.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Person> Read()
        {
            List<Person> personList = new List<Person>();
            string q = "SELECT * FROM people";
            MySqlCommand cmd_Read = new MySqlCommand(q, connection);
            try
            {
                connection.Open();
                using (MySqlDataReader reader = cmd_Read.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personList.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                    }
                }
                connection.Close();
                return personList;
            }
            catch
            {
                return personList;
            }
        }

        public bool Update(UpdateModel Umodel)
        {
            string q = $"UPDATE people SET {Umodel.Field} = @value WHERE id = @PersonaId;";
            MySqlCommand cmd_Update = new MySqlCommand(q, connection);
            cmd_Update.Parameters.AddWithValue("@value", Umodel.Value);
            cmd_Update.Parameters.AddWithValue("@PersonaId", Umodel.PId);
            try
            {
                connection.Open();
                cmd_Update.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int PersonaId)
        {
            string q = "DELETE FROM people WHERE id=@PersonaId";
            MySqlCommand cmd_Delete = new MySqlCommand(q, connection);
            cmd_Delete.Parameters.AddWithValue("@PersonaID", PersonaId);
            try
            {
                connection.Open();
                cmd_Delete.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }
    }
}
