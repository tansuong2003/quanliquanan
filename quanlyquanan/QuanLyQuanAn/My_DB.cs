using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*using System.Data.SqlClient;*/

namespace QuanLyQuanAn
{
    internal class My_DB
    {
        //Tao 2 bien cuc bo
        public static readonly string strCon = @"Data Source=THEBIN\THEBIN;Initial Catalog=QuanLyQuanAn;Integrated Security=True; User ID=sa; Password=123456";
        //Doi tuong ket noi
        public static SqlConnection sqlCon = new SqlConnection(strCon);

        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from users where userName ='"+user+ "' and uPass ='" + pass +"' ";
            SqlCommand cmd = new SqlCommand(qry, sqlCon);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if(dt.Rows.Count > 0) {  isValid = true; }
            return isValid;
        }

       /* public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        SqlConnection conAdmin = new SqlConnection(@"Data Source=LAPTOP-TSVFN4HJ;Initial
Catalog=QUANLYQUANCOFFEE_Cur;Integrated Security=True");
        public SqlConnection getConnectionAdmin
        {
            get
            {
                return conAdmin;
            }
        }
        // open the connection
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void openConnectionAdmin()
        {
            if (conAdmin.State == ConnectionState.Closed)
            {
                conAdmin.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void closeConnectionAdmin()
        {
            if (conAdmin.State == ConnectionState.Open)
            {
                conAdmin.Close();
            }
        }*/
    }
}
