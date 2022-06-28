using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2
{
    public class Class1
    {
       
        public static DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dt.Load(dr);
                }

                dr.Dispose();
            }
            catch (Exception ex)
            {

                //throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }


        public static bool Execute(SqlCommand cmd)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

    }
}
