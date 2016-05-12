using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HBGDatorServiceDAL.POCO
{
    public class Disconnected
    {
        //private SqlDataAdapter sqlDataAdapter;//Titta på detta för en riktig "Disconnected"
        //private DataSet dataSet;
        //public static DataTable GetPersons()
        //{
        //    DataTable table = new DataTable("Person finder application Fisk");
        //    using (var conn = DB.GetSqlConnection())
        //    {
        //        var command = new SqlCommand(@"SELECT * FROM [Person].[dbo].[Person]", conn);
        //        var adapter = new SqlDataAdapter(command);
        //        var res = adapter.Fill(table);
        //    }
        //    return table;
        //}
        //public static void UpdatePersons(DataTable table)
        //{
        //    var adapter = new SqlDataAdapter(@"SELECT * FROM [Person].[dbo].[Person]", DB.GetSqlConnection());
        //    var builder = new SqlCommandBuilder(adapter);
        //    adapter.Update(table);

        //}
    }
}
