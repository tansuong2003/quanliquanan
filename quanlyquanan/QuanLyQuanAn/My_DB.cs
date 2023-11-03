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
        public static readonly string strCon = @"Data Source=LAPTOP-K6GL17UI\NHATLINH;Initial Catalog=QuanLyQuanAn;Integrated Security=True; User ID=sa; Password=123456";
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
            if(dt.Rows.Count > 0) 
            {  
                isValid = true; 
                USER = dt.Rows[0]["uName"].ToString();
            }
            return isValid; 
        }

        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
       
    }
}
