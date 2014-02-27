using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace FinalA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insert/{name}/{pwd}")]
        public string insertVendor(string name, string pwd)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into vendor(name,pwd)values('" + name + "','" + pwd + "')", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return "Your name and password were successfully inserted into the database";
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "delete/{name}")]
        public string deleteVendor(string name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from vendor where name='" + name + "'", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            return "Your name and password were successfully deleted from the database";
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "query/{name}")]
                public string queryVendor(string name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            string name1 = "";
            string pwd = "";


            SqlCommand cmd = new SqlCommand("select * from vendor where name='" + name + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                name1 = reader["name"].ToString();
                pwd = reader["pwd"].ToString();

            }
            reader.Close();
            conn.Close();

            return "Vendor info:" + "Name:" + name1 + ", Your Password:" + pwd;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
