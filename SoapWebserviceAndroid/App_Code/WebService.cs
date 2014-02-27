using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    string[,] codes =

    {

     {"64112","Kansas City","10","MO"},

     {"64113","Manhattan","11","NY"},

     {"64114","Dalla","12","TX"},

     {"64115","California","13","LA"},

    

    };
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   

    [WebMethod]

    public string GetCity(string ZipCode)
    {

      
        for (int i = 0; i < codes.GetLength(0); i++)
        {

            if (String.Compare(ZipCode, codes[i, 0], true) == 0)

                return codes[i, 1];

        }

        return "City does not exist with this ZipCode";

    }




    [WebMethod]

    public float GetMiles(string ZipCode)
    {

      

        for (int i = 0; i < codes.GetLength(0); i++)
        {

            if (String.Compare(ZipCode, codes[i, 0], true) == 0)

                return float.Parse(codes[i, 2]);

        }

        return 0;

    }



    [WebMethod]

    public string GetState(string ZipCode)
    {

     
        for (int i = 0; i < codes.GetLength(0); i++)
        {

            if (String.Compare(ZipCode, codes[i, 0], true) == 0)

                return codes[i, 3];

        }

        return "State does not exist with this ZipCode";

    }

    [WebMethod]

    public string[] GetAll()
    {

        
        string[] zts = new string[codes.GetLength(0)];

        for (int i = 0; i < codes.GetLength(0); i++)
        {

            zts[i] = codes[i, 0];

        }

        return zts;

    }
}
