using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace HBGDatorServiceDAL.POCO
{
     public class About
    {
        public int ID { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Rubrik")]
        public string Header { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Innehåll")]
        public string Textfield { get; set; }

        public About()
        {

        }

        public About(string header, string textfield)
        {
            Header = header; 
            Textfield = textfield;
        }
        public override string ToString()
        {
            return string.Format("ID:{0}, Header:{1} Textfield:{2}", ID, Header, Textfield);
        }

        public void Load(SqlDataReader reader)
        {
            ID = int.Parse(reader["ID"].ToString());
            Header = reader["Header"].ToString();
            Textfield = reader["Textfield"].ToString();
        }
    }
}