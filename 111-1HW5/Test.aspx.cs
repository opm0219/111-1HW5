using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1HW5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Conn = ConfigurationManager.ConnectionStrings["SQLLOCALDB"].ConnectionString;
            SqlConnection o_Conn = new SqlConnection(s_Conn);
            o_Conn.Open();
            SqlDataAdapter o_A = new SqlDataAdapter("select * from Users", o_Conn);
            DataSet o_D = new DataSet();
            o_A.Fill(o_D, "ds_Res");
            gd_View.DataSource = o_D;
            gd_View.DataBind();
            o_Conn.Close();
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            string s_Conn = ConfigurationManager.ConnectionStrings["SQLLOCALDB"].ConnectionString;
            try
            {
                SqlConnection o_Conn = new SqlConnection(s_Conn);
                SqlDataAdapter o_A = new SqlDataAdapter("select * from Users", o_Conn);
                o_Conn.Open();
                SqlCommand o_cmd = new SqlCommand("Insert into Users (Name, Birthday) " + "values(@Name,@DateTime)", o_Conn);
                o_cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                o_cmd.Parameters["@Name"].Value = "阿貓阿狗";
                o_cmd.Parameters.Add("@DateTime", SqlDbType.DateTime);
                o_cmd.Parameters["@DateTime"].Value = "2000/10/10";
                o_cmd.ExecuteNonQuery();
                Response.Redirect("https://localhost:44393/Test.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                o_Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
        }
    }
}