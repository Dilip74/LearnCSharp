using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString;
        SqlConnection conn;

        //connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb ;User ID=sa;Password=demol23";

        //conn = new SqlConnection(connetionString);

        //conn.Open();

        Response.Write("Connection MAde");
        //conn.Close();
    }
}