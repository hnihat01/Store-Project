using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace Store_Project
{
    public partial class Form3 : Form
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        SqlDataAdapter adapt;
        DataTable dataTable = new DataTable();
        SqlCommandBuilder scb;

        public Form3()
        {
            InitializeComponent();

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "123456";
            builder.Database = "store";
            builder.SslMode = MySqlSslMode.None;
            con = new MySqlConnection(builder.ToString());
            // MySqlTransaction tr = null;
            // con.ConnectionString=ConfigurationM

            // con.Open();
            // DataTable dt = new DataTable();
            //adapt = new SqlDataAdapter("select * from product", con);
            //adapt.Fill(dt);
            // dataGridView1.DataSource = dt;

            //con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string sqlquery = "select * from product";
            MySqlCommand sqlCommand = new MySqlCommand(sqlquery, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM product ORDER BY name ASC";

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
        private DataTable GetProductList()
        {
            DataTable product = new DataTable();

            return product;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();


            /*
             string p = textBox3.Text;
             float price = (float)(Convert.ToDouble(p));



             try
             {
                 //This is my connection string i have assigned the database file address path
                 string MyConnection2 = "datasource=localhost;port=3306;username=root;password=5505667Sa";
                 //This is my update query in which i am taking input from the user through windows forms and update the record.
                 string Query = "update store.product set idproduct='"+ int.Parse(this.textBox1.Text) + "', brand='" + this.textBox2.Text + "', description='" + this.textBox3.Text + "', price='" + price + "', expire_date='" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "', count='" + int.Parse(this.textBox6.Text) + "' where idproduct='" + int.Parse(this.textBox7.Text) + "';";
                 //This is  MySqlConnection here i have created the object and pass my connection string.
                 MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                 MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                 MySqlDataReader MyReader2;
                 MyConn2.Open();
                 MyReader2 = MyCommand2.ExecuteReader();
                 MessageBox.Show("Data Updated");
                 while (MyReader2.Read())
                 {
                 }
                 MyConn2.Close();//Connection closed here
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

             */

        }
      

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetProductList();
            string mcon = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(mcon);
            string sqlquery = "select * from product";
            MySqlCommand sqlCommand = new MySqlCommand(sqlquery, mySql);
            mySql.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            mySql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=123456";
                string Query = "delete from store.product where idproduct='" + int.Parse(this.textBox7.Text) + "';";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
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
