using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
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
        //Method for curd operation
        public static int SQl(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, sqlCon);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (sqlCon.State == ConnectionState.Closed) { sqlCon.Open(); }
                res = cmd.ExecuteNonQuery();
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                sqlCon.Close();
            }
            return res;

        }
        //For loading data from database
        public static void LoadData(String qry,DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, sqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for(int i = 0; i< lb.Items.Count; i++) 
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }
                gv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                sqlCon.Close();
            }
        }
       
    }
}
