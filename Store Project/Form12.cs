using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Store_Project
{
    public partial class Form12 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;
        public Form12()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Now;
           // today.Value.ToString("yyyy-MM-dd");
           string date = today.Value.ToString("yyyy-MM-dd");
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());

            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string Query = "select  product.idproduct, product.Brand, product.Expire_date from product "
               + "WHERE  product.Expire_date<='" + date+ "' ;";
              
            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();

        }
        private DataTable GetProductList()
        {
            DataTable product = new DataTable();

            return product;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Now.AddDays(1);
            string date = today.Value.ToString("yyyy-MM-dd");
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());

            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string Query = "select  product.idproduct, product.Brand, product.Expire_date from product "
               + "WHERE  product.Expire_date='" + date + "' ;";

            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Now.AddMonths(3);
            string date = today.Value.ToString("yyyy-MM-dd");
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());

            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string Query = "select  product.idproduct, product.Brand, product.Expire_date from product "
               + "WHERE  product.Expire_date>='" + date + "' ;";

            MySqlCommand sqlCommand = new MySqlCommand(Query, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            f3.Show();
            this.Hide();
        }
    }
}
