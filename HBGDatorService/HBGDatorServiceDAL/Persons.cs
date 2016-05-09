using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class Persons
    {
        //CRUD-Create Read Update Delete
        public Person GetPersons(int personId)
        {
            var person = new Person();
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [PersonID],[FirstName],[LastName],[Email] FROM
                                                   [Person].[dbo].[Person] WHERE  [PersonID] ={0}";
                    command.CommandText = string.Format(command.CommandText, personId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        person.Load(reader);

                }
            }
            return person;
        }
        public int UpdatePerson(Person person)
        {
            using (var connection = DB.GetSqlConnection())
            {
                var sqlQuery = new StringBuilder(@"UPDATE [dbo].[Person] ");
                sqlQuery.Append("SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email ");
                sqlQuery.Append("WHERE [PersonID] = @PersonID ");
                using (var command = new SqlCommand(sqlQuery.ToString(), connection))
                {
                    command.Parameters.Add("FirstName", SqlDbType.NChar, 20).Value = person.FirstName;
                    command.Parameters.Add("LastName", SqlDbType.NChar, 20).Value = person.LastName;
                    command.Parameters.Add("Email", SqlDbType.NChar, 40).Value = person.Email;
                    command.Parameters.Add("PersonID", SqlDbType.BigInt).Value = person.PersonId;
                    int affectedRowns = command.ExecuteNonQuery();

                    return affectedRowns;
                }
            }
        }
        public int DeletePerson(int personID)
        {
            using (var conn = DB.GetSqlConnection())
            {
                var sqlQuery = new StringBuilder(@"DELETE FROM [Person].[dbo].[Person] WHERE [PersonID] = @ PersonID");
                using (var command = new SqlCommand(sqlQuery.ToString(), conn))
                {
                    command.Parameters.Add("PersonID", SqlDbType.BigInt).Value = personID;
                    int affectedRowns = command.ExecuteNonQuery();
                    return affectedRowns;
                }
            }
        }
        public int InsertPerson(Person person)
        {
            var sqlQuery = new StringBuilder(@"INSERT INTO [dbo].[Person] ([FirstName] ,[LastName],[Email]) ");
            sqlQuery.Append("VALUES (@FistName, @LastName, @Email)");
            using (var connection = DB.GetSqlConnection())
            {

                using (var command = new SqlCommand(sqlQuery.ToString(), connection))
                {
                    command.Parameters.Add("FistName", SqlDbType.NChar, 20).Value = person.FirstName;
                    command.Parameters.Add("LastName", SqlDbType.NChar, 20).Value = person.LastName;
                    command.Parameters.Add("Email", SqlDbType.NChar, 40).Value = person.Email;
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }

            }
        }
    }
    public class Person
    {


        //load-metod för en Adapter!!! :-)
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, string email, int personId = 0)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public override string ToString()
        {
            return string.Format("PersonID:{0}, FirstName:{1}, LastName:{2} Email:{3}", PersonId, FirstName, LastName, Email);
        }

        public void Load(SqlDataReader reader)
        {
            PersonId = int.Parse(reader["PersonID"].ToString());

            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            Email = reader["Email"].ToString();
        }
    }
}
