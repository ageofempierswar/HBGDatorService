using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HBGDatorServiceDAL.POCO
{
    public class Abouts
    {
        public About GetPersons(int ID)
        {
            var person = new About();
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [PersonID],[FirstName],[LastName], FROM
                                                   [Person].[dbo].[Person] WHERE  [ID] ={0}";
                    command.CommandText = string.Format(command.CommandText, ID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        person.Load(reader);

                }
            }
            return person;
        }
        //header
        //textfield
        public int UpdatePerson(About person)
        {
            using (var connection = DB.GetSqlConnection())
            {
                var sqlQuery = new StringBuilder(@"UPDATE [dbo].[Person] ");
                sqlQuery.Append("SET [Header] = @Header, [Textfield] = @Textfield");
                sqlQuery.Append("WHERE [ID] = @PersonID ");
                using (var command = new SqlCommand(sqlQuery.ToString(), connection))
                {
                
                    command.Parameters.Add("Header", SqlDbType.NChar, 20).Value = person.Header;
                    command.Parameters.Add("Textfield", SqlDbType.NChar, 20).Value = person.Textfield;
                    command.Parameters.Add("ID", SqlDbType.BigInt).Value = person.ID;
                    int affectedRowns = command.ExecuteNonQuery();

                    return affectedRowns;
                }
            }
        }
        public int DeletePerson(int ID)
        {
            using (var conn = DB.GetSqlConnection())
            {
                var sqlQuery = new StringBuilder(@"DELETE FROM [Person].[dbo].[Person] WHERE [ID] = @ ID");
                using (var command = new SqlCommand(sqlQuery.ToString(), conn))
                {
                    command.Parameters.Add("ID", SqlDbType.BigInt).Value = ID;
                    int affectedRowns = command.ExecuteNonQuery();
                    return affectedRowns;
                }
            }
        }
        public int InsertPerson(About person)
        {
            var sqlQuery = new StringBuilder(@"INSERT INTO [dbo].[Person] ([Header] ,[Textfield],[Email]) ");
            sqlQuery.Append("VALUES (@Header, @Textfield, @Email)");
            using (var connection = DB.GetSqlConnection())
            {

                using (var command = new SqlCommand(sqlQuery.ToString(), connection))
                {
                    command.Parameters.Add("Header", SqlDbType.NChar, 20).Value = person.Header;
                    command.Parameters.Add("Textfield", SqlDbType.NChar, 20).Value = person.Textfield;
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }

            }
        }

    }
}