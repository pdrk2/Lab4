using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   
    [WebMethod]
    public string insertVendor(int id, string pwd)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert into details(id,pwd)values('" + id + "','" + pwd + "')", conn);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        return "Your id and password were successfully inserted to the database";
    }

    [WebMethod]
    public string deleteVendor(int id)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete from details where id='" + id + "'", conn);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        return "Your id and password were successfully deleted from the database";
    }
    [WebMethod]
    public string queryVendor(int id)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
        conn.Open();
        string id1 = "";
        string pwd = "";


        SqlCommand cmd = new SqlCommand("select * from details where id='" + id + "'", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            
            id1 =  reader["id"].ToString();
            pwd = reader["pwd"].ToString();

        }
        reader.Close();
        conn.Close();

        return "Vendor info:" + "Id:" + id1 + ", Your Password:" + pwd;
    }
   
}
