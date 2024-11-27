using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    string sqlcon = ConfigurationManager.ConnectionStrings["cs"].ToString();
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(sqlcon))
        {
            SqlCommand cmd = new SqlCommand("emp3_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@eid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ena", TextBox2.Text);
            cmd.Parameters.AddWithValue("@edep", TextBox3.Text);
            cmd.Parameters.AddWithValue("@eloc", TextBox4.Text);
            cmd.Parameters.AddWithValue("@esal", TextBox5.Text);

            connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                Response.Write("Record Inserted Successfully");
            }
            connection.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(sqlcon))
        {
            SqlCommand cmd = new SqlCommand("emp3_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@eid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ena", TextBox2.Text);
            cmd.Parameters.AddWithValue("@edep", TextBox3.Text);
            cmd.Parameters.AddWithValue("@eloc", TextBox4.Text);
            cmd.Parameters.AddWithValue("@esal", TextBox5.Text);

            connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                Response.Write("Record Updated Successfully");
            }
            connection.Close();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
     
        int empIdToDelete;
        if (int.TryParse(TextBox1.Text, out empIdToDelete)) 
        {
            using (SqlConnection connection = new SqlConnection(sqlcon))
            {
                SqlCommand cmd = new SqlCommand("emp3_Delete", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eid", empIdToDelete);

                connection.Open();
                
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    Response.Write("Record Deleted Successfully");
                }
                else
                {
                    Response.Write("No record found with that ID");
                }

                connection.Close();
            }
        }
        else
        {
            
            Response.Write("Please enter a valid employee ID.");
        }
    }

}