using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Store_Project
{
    public partial class Form9 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;
        public Form9()
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

        private void Form9_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string sqlquery = "select * from sales";
            MySqlCommand sqlCommand = new MySqlCommand(sqlquery, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();
        }

        private DataTable GetProductList()
        {
            DataTable sales = new DataTable();

            return sales;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM sales";

                con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                cmd = new MySqlCommand(sql, con);

                con.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=123456";
                string Query = "delete from store.sales where idSales='" + int.Parse(this.textBox7.Text) + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string sqlquery = "select * from sales";
            MySqlCommand sqlCommand = new MySqlCommand(sqlquery, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
